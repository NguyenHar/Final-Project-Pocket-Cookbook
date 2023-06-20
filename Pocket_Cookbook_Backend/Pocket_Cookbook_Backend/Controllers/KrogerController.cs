using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pocket_Cookbook_Backend.Models;
using static Pocket_Cookbook_Backend.Models.KrogerDAL;

namespace Pocket_Cookbook_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KrogerController : ControllerBase
    {
        public KrogerDAL api = new KrogerDAL();
        private readonly CookbookContext db;

        public KrogerController(CookbookContext db)
        {
            this.db = db;
        }

        [HttpGet("DummyQuery")]
        public AccessToken getToken()
        {
            return api.GetProductToken();
        }

        [HttpGet("ProductSearch/{query}")]
        public Object GetKrogerProduct(string query)
        {
            string token = api.validateToken(db);
            return api.GetProduct(token, query);
        }

        
        [HttpPost]
        public async Task<ActionResult<TokenStorage>> PostRecipe(TokenStorage recipe)
        {
            if (db.tokenstorage == null)
            {
                return Problem("Entity set 'CookbookContext.Recipes'  is null.");
            }
            db.tokenstorage.Add(recipe);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetRecipe", new { id = recipe.primary_key_id }, recipe);
        }

    }

    
}
