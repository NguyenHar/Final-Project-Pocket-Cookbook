using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
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

        // Add entries to the database based on a specified query
        // Syntax: param=value&param2=value2&param3=value3
        // See https://spoonacular.com/food-api/docs
        // Returns: Primary key of meal
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

        // Uses the Id from FillDbCustomQuery() to search the db
        // Returns: List of results matching the meal id
        [HttpGet("RetrieveCustomQueryResults")]
        public async Task<ActionResult<IEnumerable<Result>>> RetrieveDbCustomQuery(int id)
        {
            List<Result> result = db.Results.Where(x => x.meal.primary_key_id == id).ToList();
            return result;
        }

        // Used for testing purposes
        [HttpGet("DummyQuery")]
        public Meal DummyQuery(string query)
        {
            return api.SearchMeals(query);
        }

        // Searches the database for the meal object by id
        // First delete all of its associated results by foreign key
        // Then delete the meal
        [HttpDelete("DeleteMealById")]
        public async Task<IActionResult> DeleteMealById(int id)
        {
            List<Result> result = db.Results.Where(x => x.meal.primary_key_id == id).ToList();
            foreach (Result r in result)
            {
                db.Results.Remove(r);
            }
            Meal mealResult = db.Meals.Find(id);
            db.Meals.Remove(mealResult);
            db.SaveChanges();
            return NoContent();
        }


        // Purge the entire database of meal & result entries
        [HttpDelete("DeleteEveryMeal")]
        public async Task<IActionResult> DeleteEveryMeal()
        {
            List<Result> result = db.Results.ToList();
            foreach (Result r in result)
            {
                db.Results.Remove(r);
            }
            List<Meal> meal = db.Meals.ToList();
            foreach (Meal m in meal)
            {
                db.Meals.Remove(m);
            }
            db.SaveChanges();

            return NoContent();
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
