using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet5_application.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet5_application.Controllers
{
    [Route("api/contactControllerMemory")]
    [ApiController]
    public class ContactControllerMemory : ControllerBase
    {

        private List<Contact> contacts = new List<Contact>
        {
            new Contact {Id = 1, Firstname = "Peter", Lastname = "Parker", Nickname = "Spiderman", Place = "New York"},
            new Contact {Id = 2, Firstname = "Tony", Lastname = "Stark", Nickname = "Iron Man", Place = "Long Island"},
        };
        // GET: api/<ContactController>
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            return Ok(contacts);
        }

        // GET api/<ContactController>/5
        [HttpGet,Route("users/{id}")]
        public ActionResult<Contact> Get(int id)
        {
            Contact contact = this.contacts.FirstOrDefault(c => c.Id == id);
            if(contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        // POST api/<ContactController>
        [HttpPost,Route("user/create")]
        public ActionResult<IEnumerable<Contact>> Post([FromBody]  Contact contact)
        {
            if(contact == null)
            {
                return BadRequest();
            }
            this.contacts.Add(contact);

            return Ok(this.contacts);

        }

        // PUT api/<ContactController>/5
        [HttpPut,Route("user/update/{id}")]
        public ActionResult Put(int id, [FromBody] Contact contact)
        {
            Contact contact1 = this.contacts.FirstOrDefault(c => id == c.Id);
            if(contact1 == null)
            {
                return NotFound();
            }

            if(contact == null)
            {

                return BadRequest();
            }

            contact1.Nickname = contact.Nickname;
            //SAVE IN CONTEXT
            return NoContent();

        }

        // DELETE api/<ContactController>/5
        [HttpDelete,Route("user/remove/{id}")]
        public ActionResult Delete(int id)
        {
            Contact contact = this.contacts.FirstOrDefault(c => id == c.Id);
            if(contact == null)
            {
                return NotFound();
            }

            contacts.Remove(contact);

            return NoContent();
        }
    }
}
