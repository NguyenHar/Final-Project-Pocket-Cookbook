using Microsoft.AspNetCore.Mvc;
using Pocket_Cookbook_Backend.Models;
using static Pocket_Cookbook_Backend.Models.KrogerDAL;

namespace Pocket_Cookbook_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KrogerController
    {
        public KrogerDAL api = new KrogerDAL();

        [HttpGet("DummyQuery")]
        public AccessToken getToken()
        {
            return api.GetProductToken();
        }



    }
}
