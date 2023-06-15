using RestSharp;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Pocket_Cookbook_Backend.Models
{
    public class RecipeDAL
    {
        string baseurl = "https://api.spoonacular.com";
        string apiKey = secret.SpoonacularApiKey;

        public Recipe GetRecipeInfo(int id)
        {
        /*  https://api.spoonacular.com/recipes/716429/information?includeNutrition=false  */
            RestClient client = new RestClient($"{baseurl}/recipes/{id}?apiKey={apiKey}");
            RestRequest request = new RestRequest();
            Task<Recipe> response = client.GetAsync<Recipe>(request);
            return response.Result;
        }
    }
}
