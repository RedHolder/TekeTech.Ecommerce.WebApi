using Customer.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerInfo>>> GetAllUsers()
        {
            var users = await _context.CustomerInfo.ToListAsync();
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerInfo>> GetUserById(string id)
        {
            var user = await _context.CustomerInfo.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<CustomerInfo>> AddUser(CustomerInfo user)
        {
            try
            {
                _context.CustomerInfo.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUserById", new { id = user.CustomerID }, user);
            }
            catch (Exception ex)
            {
                // Handle any validation errors or other exceptions
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, CustomerInfo user)
        {
            if (id != user.CustomerID)
            {
                return BadRequest("User ID in the URL does not match the ID in the request body.");
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _context.CustomerInfo.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.CustomerInfo.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(string id)
        {
            return _context.CustomerInfo.Any(e => e.CustomerID == id);
        }
    }
}
