using Microsoft.AspNetCore.Mvc;

namespace TemDeTudo.Controllers
{
    public class SellersController : Controller
    {
       public IActionResult Index()
        {
            return View();
        }
    }
}
