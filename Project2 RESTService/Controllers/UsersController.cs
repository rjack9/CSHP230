using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Project2_RESTService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project2_RESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<Users> users = new List<Users>();
        public static Guid currentId = Guid.NewGuid();
        
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = users.FirstOrDefault(t => t.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] Users value)
        {
            if (value == null)
            {
                return new BadRequestResult();
            }

            value.Id = Guid.NewGuid();
            value.CreatedDate = DateTime.Now;
            users.Add(value);

            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Users value)
        {
            var user = users.FirstOrDefault(t => t.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.Id = id;
            user.Email = value.Email;
            user.Password = value.Password;

            return Ok(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var usersRemoved = users.RemoveAll(t => t.Id == id);

            if (usersRemoved == 0)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
