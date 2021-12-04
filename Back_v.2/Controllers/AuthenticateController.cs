using Back_v._2.IdentityAuth;
using Back_v._2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Back_v._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        /// <summary>
        /// Метод регистрации пользователя
        /// </summary>
        /// <param name="model">Данные нового пользователя</param>
        /// <returns>Успешность регистрации(IActionResult)</returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(500, new Response { Status = "Error", Message = "User already exists!" });
            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(500, new Response { Status = "Error", Message = "User creation failes! Please check user details & try again." });
            return Ok(new Response { Status = "Success", Message = "User created successfully" });
        }
        /// <summary>
        /// Метод регистрации администратора
        /// </summary>
        /// <param name="model">Данные нового администратора</param>
        /// <returns>Успешность регистрации(ActionResult)</returns>
        [HttpPost]
        [Route("register-admin")]
        public async Task<ActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(500, new Response { Status = "Error", Message = "User already exists!" });
            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(500, new Response { Status = "Error", Message = "User creation failes! Please check user details & try again." });

            if (await _roleManager.RoleExistsAsync(Role.User))
                await _roleManager.CreateAsync(new IdentityRole(Role.User));

            if (await _roleManager.RoleExistsAsync(Role.Admin))
                await _userManager.AddToRoleAsync(user, Role.Admin);

            return Ok(new Response { Status = "Success", Message = "User created successfully" });
        }
        /// <summary>
        /// Метод авторизации
        /// </summary>
        /// <param name="model">Данные для для авторизации</param>
        /// <returns>Токен доступа</returns>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if(user!=null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach(var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo });
            }
            return Unauthorized();
        }
        /// <summary>
        /// Метод проверки авторизации
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<string> CheckLogin()
        {
            return HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
