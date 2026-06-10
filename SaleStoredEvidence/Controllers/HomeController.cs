using Microsoft.AspNetCore.Mvc;

namespace SaleStoredEvidence.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
