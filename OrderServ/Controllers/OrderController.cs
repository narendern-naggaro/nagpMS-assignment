using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderServ.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Invalid ID");
            }
            else
            {
                return Ok(GetOrders());
            }
        }

        private List<Orders> GetOrders()
        {
            var lstOrders = new List<Orders>
            {
                new Orders
                {
                    OrderId = 1,
                    OrderAmount = 250,
                    OrderDate = DateTime.Parse("14-Apr-2020").ToString("dd/MM/yyyy")
                },
                new Orders
                {
                    OrderId = 2,
                    OrderAmount = 450,
                    OrderDate = DateTime.Parse("15-Apr-2020").ToString("dd/MM/yyyy")
                }
            };

            return lstOrders;
        }
    }
}