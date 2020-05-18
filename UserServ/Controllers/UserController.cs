using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;

namespace UserServ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MSDBContext _context;
        private readonly ITracer _tracer;

        public UserController(MSDBContext context,ITracer tracer)
        {
            _context = context;
            _tracer = tracer;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }

            else
            {
                _tracer.BuildSpan("Getting result for the user");
                //return Ok(_context.Users.Where(user => user.Id == 1));
                var user = new Users
                {
                    Id = 1,
                    Name = "Narender",
                    Age = 31,
                    Email = "narender@nagarro.com"
                };
                return Ok(user);
            }

        }
    }
}