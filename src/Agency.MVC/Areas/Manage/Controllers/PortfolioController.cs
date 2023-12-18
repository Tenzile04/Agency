using Microsoft.AspNetCore.Mvc;

namespace Agency.MVC.Areas.Manage.Controllers
{
    [Area("manage")]
    public class PortfolioController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
