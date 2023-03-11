using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using petshop_management.Data;
using petshop_management.Models;

namespace petshop_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly ClientContext _context;

        public ClientController(ClientContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            var result = _context.Clients.ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Client> GetClient(int id)
        {
            var client = _context.Clients.Find(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPost]
        public ActionResult<Client> PostClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
        }

    }
}