using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pocket_Cookbook_Backend.Models;

namespace Pocket_Cookbook_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavoritesController : ControllerBase
    {
        private readonly CookbookContext db;

        public UserFavoritesController(CookbookContext context)
        {
            db = context;
        }

        // Searches the database and return as list of results that the user favorited
        [HttpGet("GetUserFavorites")]
        public async Task<ActionResult<IEnumerable<Result>>> GetUserFavorites(string userid)
        {
            List<int> toSearch = db.userFavorites.Where(x => x.googleId == userid).Select(x => x.resultFK).ToList();
            List<Result> resultList = new List<Result>();
            foreach (int item in toSearch)
            {
                resultList.Add(db.Results.FirstOrDefault(x => x.primary_key_id == item));
            }

            return resultList;
        }

        // Adds favorited result from the user to the database
        [HttpPost("AddUserFavorite")]
        public async Task<ActionResult> AddUserFavorite(string userid, int resultPKId)
        {
            if (db.userFavorites.Any(x => x.googleId == userid && x.resultFK == resultPKId))
            {
                return NoContent();
            }
            else
            {
                UserFavorites newFavorite = new UserFavorites();
                newFavorite.primary_key_id = 0;
                newFavorite.googleId = userid;
                newFavorite.resultFK = resultPKId;
                db.userFavorites.Add(newFavorite);
                db.SaveChanges();
                return NoContent();
            }
        }

        // Removes favorited result of the user from the database
        [HttpDelete("RemoveUserFavorite")]
        public async Task<ActionResult> RemoveUserFavorite(string userid, int resultPKId)
        {
            UserFavorites target = db.userFavorites.FirstOrDefault(x => x.googleId == userid && x.resultFK == resultPKId);
            if (target != null)
            {
                db.userFavorites.Remove(target);
                db.SaveChanges();
            }
            return NoContent();
        }


        //    // GET: api/UserFavorites
        //    [HttpGet]
        //    public async Task<ActionResult<IEnumerable<UserFavorites>>> GetuserFavorites()
        //    {
        //      if (_context.userFavorites == null)
        //      {
        //          return NotFound();
        //      }
        //        return await _context.userFavorites.ToListAsync();
        //    }

        //    // GET: api/UserFavorites/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<UserFavorites>> GetUserFavorites(int id)
        //    {
        //      if (_context.userFavorites == null)
        //      {
        //          return NotFound();
        //      }
        //        var userFavorites = await _context.userFavorites.FindAsync(id);

        //        if (userFavorites == null)
        //        {
        //            return NotFound();
        //        }

        //        return userFavorites;
        //    }

        //    // PUT: api/UserFavorites/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutUserFavorites(int id, UserFavorites userFavorites)
        //    {
        //        if (id != userFavorites.primary_key_id)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(userFavorites).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserFavoritesExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/UserFavorites
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<UserFavorites>> PostUserFavorites(UserFavorites userFavorites)
        //    {
        //      if (_context.userFavorites == null)
        //      {
        //          return Problem("Entity set 'CookbookContext.userFavorites'  is null.");
        //      }
        //        _context.userFavorites.Add(userFavorites);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetUserFavorites", new { id = userFavorites.primary_key_id }, userFavorites);
        //    }

        //    // DELETE: api/UserFavorites/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteUserFavorites(int id)
        //    {
        //        if (_context.userFavorites == null)
        //        {
        //            return NotFound();
        //        }
        //        var userFavorites = await _context.userFavorites.FindAsync(id);
        //        if (userFavorites == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.userFavorites.Remove(userFavorites);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool UserFavoritesExists(int id)
        //    {
        //        return (_context.userFavorites?.Any(e => e.primary_key_id == id)).GetValueOrDefault();
        //    }
    }
}
