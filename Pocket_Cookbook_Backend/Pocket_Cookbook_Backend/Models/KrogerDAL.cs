using Newtonsoft.Json;
using NuGet.Protocol;
using RestSharp;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Pocket_Cookbook_Backend.Models
{
    public class KrogerDAL
    {
        string baseUrl = "https://api.kroger.com/v1/";
        string grant_type = "client_credentials";


        string client_id = secret.KrogerClientId;
        string client_secret = secret.KrogerClientSecret;




        public class AccessToken
        {
            public int expires_in { get; set; }
            public string access_token { get; set; }
            public string token_type { get; set; }
        }

        public AccessToken GetProductToken()
        {
            RestClient client = new RestClient("https://api.kroger.com/v1/connect/oauth2/token");
            RestRequest request = new RestRequest();

            request.AddHeader("Authorization", "Basic cG9ja2V0Y29va2Jvb2stN2MyNTZhMjAwOTk3N2NiOGRkMzQxZjVkYmMyOTIyZmIxMjQxMDU5OTU3NDUzNDA1Njc4OlYwX2FEb3dHRVRxT3VLek4wcEJGR2xqSmxDQmNfNklCRXRNbnVtWlk=");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("scope", "product.compact");

            Task<AccessToken> response = client.PostAsync<AccessToken>(request);
            AccessToken at = response.Result;
            return at;

        }

        public KrogerProduct GetProduct(AccessToken at, string query)
        {
            RestClient client = new RestClient(baseUrl + $"products?filter.term={query}&filter.limit=10");
            RestRequest request = new RestRequest();
            request.AddHeader("Bearer", at.access_token);
            Task<KrogerProduct> response = client.GetAsync<KrogerProduct>(request);
            KrogerProduct kp = response.Result;
            return kp;
        }

    }
}
