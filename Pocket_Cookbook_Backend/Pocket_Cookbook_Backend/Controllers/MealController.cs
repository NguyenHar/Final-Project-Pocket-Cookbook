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
    public class MealController : ControllerBase
    {
        public MealDAL api = new MealDAL();
        private readonly CookbookContext db;

        public MealController(CookbookContext context)
        {
            db = context;
        }

        [HttpGet("FillDbCustomQuery")]
        public async Task<ActionResult<int>> FillDbCustomQuery(string query)
        {
            //query = "cuisine=italian&number=3";
            Meal m = api.SearchMeals(query);
            m.primary_key_id = 0;

            db.Meals.Add(m);
            db.SaveChanges();
            return m.primary_key_id;
        }

        /*
        // GET: api/Meal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meal>>> GetMeals()
        {
          if (db.Meals == null)
          {
              return NotFound();
          }
            return await db.Meals.ToListAsync();
        }

        // GET: api/Meal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meal>> GetMeal(int id)
        {
          if (db.Meals == null)
          {
              return NotFound();
          }
            var meal = await db.Meals.FindAsync(id);

            if (meal == null)
            {
                return NotFound();
            }

            return meal;
        }

        // PUT: api/Meal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeal(int id, Meal meal)
        {
            if (id != meal.id)
            {
                return BadRequest();
            }

            db.Entry(meal).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealExists(id))
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

        // POST: api/Meal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Meal>> PostMeal(Meal meal)
        {
          if (db.Meals == null)
          {
              return Problem("Entity set 'CookbookContext.Meals'  is null.");
          }
            db.Meals.Add(meal);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetMeal", new { id = meal.id }, meal);
        }

        // DELETE: api/Meal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            if (db.Meals == null)
            {
                return NotFound();
            }
            var meal = await db.Meals.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }

            db.Meals.Remove(meal);
            await db.SaveChangesAsync();

            return NoContent();
        }

        private bool MealExists(int id)
        {
            return (db.Meals?.Any(e => e.id == id)).GetValueOrDefault();
        }
        */
    }
}
