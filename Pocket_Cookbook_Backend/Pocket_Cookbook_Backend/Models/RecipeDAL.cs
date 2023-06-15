using RestSharp;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Pocket_Cookbook_Backend.Models
{
    public class RecipeDAL
    {
        string baseurl = "https://api.spoonacular.com";
        string apiKey = secret.SpoonacularApiKey;

        // Gets information about a single recipe
        // Syntax: id
        // Return single recipe object
        public Recipe GetRecipeInfo(int id)
        {
        /*  https://api.spoonacular.com/recipes/716429/information?includeNutrition=false  */
            RestClient client = new RestClient($"{baseurl}/recipes/{id}/information?includeNutrition=false&apiKey={apiKey}");
            RestRequest request = new RestRequest();
            Task<Recipe> response = client.GetAsync<Recipe>(request);
            return response.Result;
        }

        // Gets information about recipes
        // Syntax: id,id2,id3,id4
        // Return list of recipes from the endpoint
        public List<Recipe> GetRecipeInfoBulk(string ids)
        {
            /* https://api.spoonacular.com/recipes/informationBulk?ids=715538,716429 */
            RestClient client = new RestClient($"{baseurl}/recipes/informationBulk?ids={ids}&includeNutrition=false&apiKey={apiKey}");
            RestRequest request = new RestRequest();
            Task<List<Recipe>> response = client.GetAsync<List<Recipe>>(request);
            return response.Result;
        }
    }
}
