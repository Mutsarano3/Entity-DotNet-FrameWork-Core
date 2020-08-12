using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnet5_application.Data;
using dotnet5_application.Models;

namespace dotnet5_application.Controllers
{
    [Route("api/contactControllerDb")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Contacts
        
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return await _context.Contacts.Where(c => c.isDeleted == false).ToListAsync();
        }

        // GET: api/Contacts/5
        [HttpGet, Route("users/{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [HttpPut, Route("user/update/{id}")]
        public async Task<IActionResult> PutContact(int id, Contact contact)
        {
            var dbContact = await _context.Contacts.FindAsync(id);
            if(dbContact == null)
            {
                return NotFound();
            }

            dbContact.Firstname = contact.Firstname;
            dbContact.Lastname = contact.Lastname;
            dbContact.Nickname = contact.Nickname;
            dbContact.Place = contact.Place;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Contacts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost, Route("user/create")]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5
        [HttpDelete, Route("user/remove/{id}")]
        public async Task<ActionResult<Contact>> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
