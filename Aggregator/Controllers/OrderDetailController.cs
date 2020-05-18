using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aggregator.Controllers
{
    [Route("api/orderdetails")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            if (id == 0)
            {
                return NotFound("Invalid id");
            }
            else
            {
                using (var client = new HttpClient())
                {
                    string Baseurl = "http://localhost:54790/";
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var data = await client.GetStringAsync("user/" + id.ToString());
                    var data1 = await client.GetStringAsync("orders/" + id.ToString());

                    return Ok(new { users = data, orders = data1 });
                }
            }

        }
    }
}