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

        // [Route("Address")]
        //  public ActionResult Index()
        // {
            
        //     //var Address = new IEnumerable<Address>;
        //     var addresses = GetAddresses();
        //     ViewBag.Addresses = addresses;
            
        //     return View();
        // }
        
        // GET: Address
       [HttpGet]
        public ActionResult<IEnumerable<Address>> GetAddresses()
        {
            return _context.Addresses.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Address> GetAddress(int id)
        {
            var Address = _context.Addresses.Find(id);

            if (Address == null)
            {
                return NotFound();
            }

            return Address;
        }

        [HttpPost]
        public ActionResult<Address> PostAddress(Address Address)
        {
            _context.Addresses.Add(Address);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAddress), new { id = Address.Id }, Address);
        }

    }
}