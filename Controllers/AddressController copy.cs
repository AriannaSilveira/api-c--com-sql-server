using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using petshop_management.Data;
using petshop_management.Models;

namespace petshop_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly AddressContext _context;

        public AddressController(AddressContext context)
        {
            _context = context;
        }

       [HttpGet]
        public ActionResult<IEnumerable<Address>> GetAddresses()
        {
            var result = _context.Addresses.ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Address> GetAddress(int id)
        {
            var address = _context.Addresses.Find(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        [HttpPost]
        public ActionResult<Address> PostAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAddress), new { id = address.Id }, address);
        }

    }
}