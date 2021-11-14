using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BackEnd.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserContext _context;

        public AccountController(UserContext context)
        {
            _context = context;
        }

        [HttpPost("/token")]
        public async Task<ActionResult<TokenClass>> Token(string email, string password)
        {
            var identity = GetIdentity(email, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            TokenClass response = new TokenClass(encodedJwt, identity.Name);

            return response;
        }
        private ClaimsIdentity GetIdentity(string email, string password)
        {
            var users = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (users != null)
            {
                var claims = new List<Claim>    
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, users.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, users.UserRoleId.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
        //public async Task<ClaimsIdentity> GetIdentityAsync(string email, string password)
        //{
        //    if (string.IsNullOrEmpty(email))
        //    {
        //        throw new ArgumentNullException(nameof(email));
        //    }
        //    if (string.IsNullOrEmpty(password))
        //    {
        //        throw new ArgumentNullException(nameof(password));
        //    }
        //    var users = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        //    if (users != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimsIdentity.DefaultNameClaimType, users.Email),
        //            new Claim(ClaimsIdentity.DefaultRoleClaimType, users.UserRole.ToString())
        //        };
        //        ClaimsIdentity claimsIdentity =
        //        new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
        //            ClaimsIdentity.DefaultRoleClaimType);
        //        return claimsIdentity;
        //    }

        //    // если пользователя не найдено
        //    return null;
        //}

        [HttpGet("/Register")]
        public IActionResult Register()
        {
            //return View();
            return RedirectToAction("Index", "Home");//заглушка
        }
        [HttpPost("/Register")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<RegisterModel>> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User(model.Email, model.Password); //{ Email = model.Email, Password = model.Password };
                    UserRole userRole = await _context.UserRoles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.UserRole = userRole;

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return model;
        }

        [HttpGet("/Login")]
        public IActionResult Login()
        {
            //return View();
            return RedirectToAction("Index", "Home");//заглушка
        }
        [HttpPost("/Login")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<LoginModel>> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users
                    .Include(u => u.UserRole)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return model;
        }
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserRole?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }


        public class TokenClass
        {
            private string access_token;
            private string username;

            public string Access_token { get => access_token; set => access_token = value; }
            public string Username { get => username; set => username = value; }

            public TokenClass(string access_token, string username)
            {
                this.Access_token = access_token ?? throw new ArgumentNullException(nameof(access_token));
                this.Username = username ?? throw new ArgumentNullException(nameof(username));
            }
        }
    }
}
