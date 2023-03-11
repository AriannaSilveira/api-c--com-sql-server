using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using petshop_management.Data;
using petshop_management.Models;

namespace petshop_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        private readonly PetContext _context;

        public PetController(PetContext context)
        {
            _context = context;
        }

       [HttpGet]
        public ActionResult<IEnumerable<Pet>> GetPets()
        {
            return _context.Pets.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> GetPet(int id)
        {
            var pet = _context.Pets.Find(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        [HttpPost]
        public ActionResult<Pet> PostPet(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, pet);
        }

    }
}