using Newtonsoft.Json;
using RestSharp;
using System.Net.Http.Headers;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Pocket_Cookbook_Backend.Models
{
    public class KrogerDAL
    {
        string baseUrl = "https://api.kroger.com/v1/";
        //string grant_type = "client_credentials";
        //string client_id = secret.KrogerClientId;
        //string client_secret = secret.KrogerClientSecret;

        class AccessToken
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public long expires_in { get; set; }
        }

        //private static async Task<string> GetToken()
        //{
        //    string clientId = secret.KrogerClientId;
        //    string clientSecret = secret.KrogerClientSecret;
        //    string credentials = String.Format("{0}:{1}", clientId, clientSecret);

        //}




            //using (var client = new HttpClient())
            //{
                ////Define Headers
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

                ////Prepare Request Body
                //List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
                //requestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

                //FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);

                ////Request Token
                //var request = await client.PostAsync($"https://api.kroger.com/v1/", requestBody);
                //var response = await request.Content.ReadAsStringAsync();
                //return JsonConvert.DeserializeObject<AccessToken>(response).ToString();
            //}

        //public KrogerProduct SearchKrogerProducts(string query)
        //{
        //    var client = new RestClient("https://service.endpoint.com/api/oauth2/token");
        //    var request = new RestRequest(Method.Post.ToString());
        //    request.AddHeader("cache-control", "no-cache");
        //    request.AddHeader("content-type", "application/x-www-form-urlencoded");
        //    request.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&client_id=abc&client_secret=123", ParameterType.RequestBody);
        //    IRestResponse response = client.Execute(request);


        //    var client = new RestClient($"https://api.kroger.com/v1/products?filter.term={query}");
        //    var request = new RestRequest();
        //    request.AddHeader("Authorization", $"{auth}");
        //    request.AddHeader("Cookie", $"{cookie}");
        //    Task<KrogerProduct> response = client.GetAsync<KrogerProduct>(request);
        //    return response.Result;

        //}

    }
}
