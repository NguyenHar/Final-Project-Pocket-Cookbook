﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pocket_Cookbook_Backend.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
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

        //Generates a new Kroger token
        [HttpGet("KrogerTokenGenerator")]
        public AccessToken getToken()
        {
            return api.GetProductToken();
        }

        //searches kroger products based upon a query
        [HttpGet("ProductSearch/{query}")]
        public KrogerProduct GetKrogerProduct(string query)
        {
            string token = api.validateToken(db);
            KrogerProduct product = api.GetProduct(token, query);

            return product;
        }

        //searches for multiple Kroger products at once
        [HttpGet("GetMultipleProducts")]
        public async Task<ActionResult<IEnumerable<KrogerProduct>>> GetMultipleProducts(string list)
        {
            List<string> queries = list.Split(',').ToList();
            List<Task<KrogerProduct>> listOfTasks = new List<Task<KrogerProduct>>();

            foreach (string query in queries)
            {
                listOfTasks.Add(DoKrogerAsync(query));
            }

            return await Task.WhenAll<KrogerProduct>(listOfTasks);
        }

        // Get kroger location near lat & long coordinates
        [HttpGet("GetKrogerLocations")]
        public async Task<ActionResult<KrogerLocation>> GetKrogerLocation(decimal Lat, decimal Long)
        {
            string token = api.validateToken(db);
            KrogerLocation location = api.GetKrogerLocation(token, Lat, Long);
            return location;
        }

        [HttpGet("DontUseThis")]
        public Task<KrogerProduct> DoKrogerAsync(string item)
        {
            //Task.Delay(100);
            string token = api.validateToken(db);
            return Task.FromResult(api.GetProduct(token, item));
        }

        /*
        [HttpGet("GetMultipleProducts")]
        public ActionResult<List<KrogerProduct>> GetMultipleProducts(string list)
        {
            List<string> queries = list.Split(',').ToList();
            List<KrogerProduct> products = new List<KrogerProduct>();
            string token = api.validateToken(db);

            foreach (string query in queries)
            {
                products.Add(api.GetProduct(token, query));
            }

            return products;
        }*/



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
