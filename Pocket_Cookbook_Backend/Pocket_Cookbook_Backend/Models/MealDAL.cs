using RestSharp;

namespace Pocket_Cookbook_Backend.Models
{
    public class MealDAL
    {
        string baseurl = "https://api.spoonacular.com";
        string apiKey = secret.SpoonacularApiKey;

        public Meal SearchMeals(string query)
        {
            RestClient client = new RestClient($"{baseurl}/recipes/complexSearch?apiKey={apiKey}&sort=random&{query}");
            RestRequest request = new RestRequest();
            Task<Meal> response = client.GetAsync<Meal>(request);
            return response.Result;
        }
    }
}
