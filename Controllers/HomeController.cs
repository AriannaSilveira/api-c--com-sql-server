using Microsoft.AspNetCore.Mvc;

namespace petshop_management.Controllers
{
    public class HomeController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}