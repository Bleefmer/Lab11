
using Microsoft.AspNetCore.Mvc;
using FilterExample.Filters;


namespace FilterExample.Controllers
{
    public class HomeController : Controller
    {
        [LogActionFilter]
        public IActionResult Index()
        {
            return View();
        }
    }
}