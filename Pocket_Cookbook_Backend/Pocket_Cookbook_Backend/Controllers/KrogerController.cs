using Microsoft.AspNetCore.Mvc;
using Pocket_Cookbook_Backend.Models;

namespace Pocket_Cookbook_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KrogerController
    {
        public KrogerDAL api = new KrogerDAL();

        [HttpGet("DummyQuery")]
        public void getToken()
        {
            getToken();
        }
    }
}
