using Azure.Core;
using Microsoft.AspNetCore.Mvc;
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
        string base64 = secret.Base64Key;



        //kroger access token object
        public class AccessToken
        {
            public int expires_in { get; set; }
            public string access_token { get; set; }
            public string token_type { get; set; }
        }


        //gets bearer token from Kroger 
        //clientID and client secret base64 encoded into one string
        public AccessToken GetProductToken()
        {
            RestClient client = new RestClient("https://api.kroger.com/v1/connect/oauth2/token");
            RestRequest request = new RestRequest();

            request.AddHeader("Authorization", $"Basic {base64}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("scope", "product.compact");

            Task<AccessToken> response = client.PostAsync<AccessToken>(request);
            AccessToken at = response.Result;
            return at;

        }


        // Get kroger location near zip code
        public KrogerLocation GetKrogerLocation(string token, decimal Lat, decimal Long)
        {
            RestClient client = new RestClient(baseUrl + $"locations?filter.latLong.near={Lat},{Long}&filter.limit=10");
            RestRequest request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {token}");
            Task<KrogerLocation> response = client.GetAsync<KrogerLocation>(request);
            KrogerLocation kl = response.Result;
            return kl;
        }


        //kroger product query
        public KrogerProduct GetProduct(string at, string query)
        {
            RestClient client = new RestClient(baseUrl + $"products?filter.term={query}&filter.locationId=01800443&filter.limit=3");
            RestRequest request = new RestRequest();
            request.AddHeader("Authorization",$"Bearer {at}");
            Task<KrogerProduct> response = client.GetAsync<KrogerProduct>(request);
            KrogerProduct kp = response.Result;
            foreach (var d in kp.data)
            {
                if (d != null)
                {
                    if (d.brand == null)
                        d.brand = "Brand not found";
                    foreach (var i in d.items)
                    {
                        if (i == null || i.price == null || i.price.regular == null)
                        {
                            i.price = new Price();
                            i.price.regular = 0;
                        }
                    }
                }
            }
            return kp;
        }

        //checks to see if token in the database is still valid, if it is, uses that one. 
        //If not retrieves a new token from kroger
        public string validateToken(CookbookContext db)
        {
            List<TokenStorage> storages = db.tokenstorage.ToList();
            TokenStorage storage = db.tokenstorage.FirstOrDefault(x => true);
            if (storage == null || (DateTime.Now - storage.dateTime).TotalSeconds > 1700 )
            {
                if (storage != null)
                {
                    db.tokenstorage.Remove(storage);
                }
                AccessToken token = GetProductToken();
                TokenStorage ts = new TokenStorage();
                ts.token = token.access_token;
                ts.dateTime = DateTime.Now;
                db.tokenstorage.Add(ts);
                db.SaveChanges();
                return storage.token;
            }
            else
            {
                return storage.token;
            }
        }

    }
}
