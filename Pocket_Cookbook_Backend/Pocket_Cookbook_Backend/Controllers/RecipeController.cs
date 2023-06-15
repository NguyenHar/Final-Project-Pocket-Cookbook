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
    public class RecipeController : ControllerBase
    {
        public RecipeDAL api = new RecipeDAL();
        private readonly CookbookContext db;

        public RecipeController(CookbookContext context)
        {
            db = context;
        }

        // Gets information about a single recipe
        // Syntax: id
        // Return single recipe object
        [HttpGet("GetRecipeInfo")]
        public async Task<ActionResult<Recipe>> GetRecipeInfo(int id)
        {
            Recipe r = api.GetRecipeInfo(id);
            r.primary_key_id = 0;
            db.Recipes.Add(r);
            db.SaveChanges();
            return Ok(r);
        }
        // Gets information about many recipes, comma separated id's
        // Syntax: id,id2,id3,id4
        // Return list of recipes from the endpoint
        [HttpGet("GetRecipeInfoBulk")]
        public async Task<ActionResult<List<Recipe>>> GetRecipeInfoBulk(string ids)
        {
            List<Recipe> r = api.GetRecipeInfoBulk(ids);
            foreach (Recipe recipe in r)
            {
                recipe.primary_key_id = 0;
                db.Recipes.Add(recipe);
            }
            db.SaveChanges();
            return Ok(r);
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
