using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back_v._2.Context;
using Back_v._2.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Back_v._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetUsersController : ControllerBase
    {
        private readonly ShopdbContext _context;

        public AspNetUsersController(ShopdbContext context)
        {
            _context = context;
        }

        //// GET: api/AspNetUsers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<AspNetUser>>> GetAspNetUsers()
        //{
        //    return await _context.AspNetUsers.ToListAsync();
        //}

        // GET: api/AspNetUsers/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetUser>> GetAspNetUser(string id)
        {
            var aspNetUser = await _context.AspNetUsers.FindAsync(id);

            if (aspNetUser == null)
            {
                return NotFound();
            }

            return aspNetUser;
        }

        // PUT: api/AspNetUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUser(string id, AspNetUser aspNetUser)
        {
            if (id != aspNetUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspNetUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AspNetUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult<AspNetUser>> PostAspNetUser(AspNetUser aspNetUser)
        {
            _context.AspNetUsers.Add(aspNetUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetUserExists(aspNetUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAspNetUser", new { id = aspNetUser.Id }, aspNetUser);
        }

        // DELETE: api/AspNetUsers/5
        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspNetUser(string id)
        {
            var aspNetUser = await _context.AspNetUsers.FindAsync(id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            _context.AspNetUsers.Remove(aspNetUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AspNetUserExists(string id)
        {
            return _context.AspNetUsers.Any(e => e.Id == id);
        }
        /// <summary>
        /// Метод получения списка пользователей
        /// </summary>
        /// <param name="paginateParameters">Параметры пагинации</param>
        /// <returns>IEnumerable<AspNetUser></returns>
        [HttpGet]
        public async Task<IEnumerable<AspNetUser>> GetAspNetUsers([FromQuery] PaginateParameters paginateParameters)
        {
            return _context.AspNetUsers.ToList()
                .OrderBy(on => on.FirstName)
                .Skip((paginateParameters.PageNumber - 1) * paginateParameters.PageSize)
                .Take(paginateParameters.PageSize)
                .Select(e => new AspNetUser
                {
                    UserName = e.UserName,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Photo = e.Photo

                })
                .ToList();
        }
        /// <summary>
        /// Метод получения списка из WishList
        /// </summary>
        /// <param name="paginateParameters">Параметры пагинации</param>
        /// <param name="id">Индекс пользователя</param>
        /// <returns><List<Product></returns>
        [Authorize]
        [HttpGet("/WishList")]
        public async Task<ActionResult<List<Product>>> GetWishList([FromQuery] PaginateParameters paginateParameters)
        {
            AspNetUser aspNetUser = _context.AspNetUsers.Where(e => e.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).Include(a => a.WishList).FirstOrDefault();
            if(aspNetUser == null)
                return NotFound();
            return aspNetUser.WishList
                .Skip((paginateParameters.PageNumber - 1) * paginateParameters.PageSize)
                .Take(paginateParameters.PageSize).ToList();
                //.Where(e => e.Id == id)
                //.Include(a => a.WishList
                //.Skip((paginateParameters.PageNumber - 1) * paginateParameters.PageSize)
                //.Take(paginateParameters.PageSize)
                //.ToList())
                //.FirstOrDefault();
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddInWishList(int productId)
        {
            var aspNetUser = await _context.AspNetUsers.FindAsync(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);//получение id пользователя
            var product = await _context.Products.FindAsync(productId);
            if (aspNetUser == null)
                return NotFound();
            aspNetUser.WishList.Add(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return Ok();
        }
    }

}
