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

        // [Route("Client")]
        //  public ActionResult Index()
        // {
            
        //     //var clients = new IEnumerable<Client>;
        //     var clients = GetClients();
        //     ViewBag.Client = clients;
            
        //     return View();
        // }
        
        // GET: Clients
       [HttpGet]
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            return _context.Clients.ToList();
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