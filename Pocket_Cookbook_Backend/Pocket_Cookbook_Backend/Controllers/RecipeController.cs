using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Pocket_Cookbook_Backend.Models;

namespace Pocket_Cookbook_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        public RecipeDAL api = new RecipeDAL();
        private readonly CookbookContext db;

        public RecipeController(CookbookContext context)
        {
            db = context;
        }

        // Searches the database for an existing query, if true return that query
        // If it doesn't exist, make an api call and store it in the database
        // Gets information about a single recipe
        // Syntax: id
        // Return single recipe object
        [HttpGet("GetRecipeInfo")]
        public async Task<ActionResult<Recipe>> GetRecipeInfo(int id)
        {
            bool found = false;
            Recipe returnRecipe = new Recipe();
            // If exists in database, return it
            foreach (Recipe r in db.Recipes)
            {
                if (r.id == id)
                {
                    returnRecipe = r;
                    found = true;
                    break;
                }
            }
            if (found)
            {
                db.extendedingredients.ToList();
                db.analyzedinstructions.ToList();
                db.steps.ToList();
                db.ingredients.ToList();
                db.equipment.ToList();
                return returnRecipe;
            }
            else
            {
                returnRecipe = api.GetRecipeInfo(id);
                db.extendedingredients.ToList();
                db.analyzedinstructions.ToList();
                db.steps.ToList();
                db.ingredients.ToList();
                db.equipment.ToList();

                db.Recipes.Add(returnRecipe);
                db.SaveChanges();

                return returnRecipe;
            }


        }
        // Gets information about many recipes, comma separated id's
        // Syntax: id,id2,id3,id4
        // Return list of recipes from the endpoint
        [HttpGet("GetRecipeInfoBulk")]
        public async Task<ActionResult<List<Recipe>>> GetRecipeInfoBulk(string ids)
        {
            List<Recipe> returnRecipes = new List<Recipe>();
            List<int> queryIds = ids.Split(',').Select(Int32.Parse).ToList();
            string nonExistingIds = "";

            // Parse the string and check if any exist in the database
            // If they do, return that recipe, else make an api call
            foreach (int id in queryIds)
            {
                Recipe recipe = db.Recipes.FirstOrDefault(x => x.id == id);
                if (recipe != null)
                {
                    returnRecipes.Add(recipe);
                }
                else
                {
                    nonExistingIds += id + ",";
                }
            }
            if (nonExistingIds != "")
            {
                nonExistingIds.TrimEnd(',');
                List<Recipe> r = api.GetRecipeInfoBulk(nonExistingIds);
                foreach (Recipe recipe in r)
                {
                    recipe.primary_key_id = 0;
                    db.Recipes.Add(recipe);
                    returnRecipes.Add(recipe);
                }
                db.SaveChanges();
            }

            db.extendedingredients.ToList();
            db.analyzedinstructions.ToList();
            db.steps.ToList();
            db.ingredients.ToList();
            db.equipment.ToList();
            return returnRecipes;
        }


        // Uses meal's result id to search the db
        // Returns: Single recipe object matching the meal id
        [HttpGet("GetSingleRecipeFromDb")]
        public async Task<ActionResult<Recipe>> GetSingleRecipeFromDb(int id)
        {
            // Grab the recipe object
            Recipe result = db.Recipes.First(y => y.id == id);

            // Calling ToList() gets the database to fill these out 
            // Doesn't work without doing this for some reason 🤷‍
            db.extendedingredients.ToList();
            db.analyzedinstructions.ToList();
            db.steps.ToList();
            db.ingredients.ToList();
            db.equipment.ToList();


            return result;
        }

        // Uses meal's result id to search the db
        // Returns: List of recipes matching the meal id
        [HttpGet("GetRecipesFromDb")]
        public async Task<ActionResult<List<Recipe>>> GetRecipesFromDb(string str)
        {
            List<int> ids = str.Split(',').Select(int.Parse).ToList();
            List<Recipe> r = new List<Recipe>();

            foreach (int id in ids)
            {
                if (db.Recipes.Any(x => x.id == id))
                {
                    r.Add(db.Recipes.First(y => y.id == id));
                }
            }

            // Calling ToList() gets the database to fill these out 
            // Doesn't work without doing this for some reason 🤷‍
            db.extendedingredients.ToList();
            db.analyzedinstructions.ToList();
            db.steps.ToList();
            db.ingredients.ToList();
            db.equipment.ToList();

            return r;
        }




        /*
        // GET: api/Recipe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
          if (_context.Recipes == null)
          {
              return NotFound();
          }
            return await _context.Recipes.ToListAsync();
        }

        // GET: api/Recipe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
          if (_context.Recipes == null)
          {
              return NotFound();
          }
            var recipe = await _context.Recipes.FindAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        // PUT: api/Recipe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, Recipe recipe)
        {
            if (id != recipe.primary_key_id)
            {
                return BadRequest();
            }

            _context.Entry(recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
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

        // POST: api/Recipe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
          if (_context.Recipes == null)
          {
              return Problem("Entity set 'CookbookContext.Recipes'  is null.");
          }
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipe", new { id = recipe.primary_key_id }, recipe);
        }

        // DELETE: api/Recipe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            if (_context.Recipes == null)
            {
                return NotFound();
            }
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeExists(int id)
        {
            return (_context.Recipes?.Any(e => e.primary_key_id == id)).GetValueOrDefault();
        }
        */
    }
}
