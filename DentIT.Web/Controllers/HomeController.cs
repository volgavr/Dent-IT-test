using DentIT.Web.ModelBinding;
using DentIT.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DentIT.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ClickCounter(string url)
        {
            //Logging 
            return Content($"Click scored");
        }
        public string Test([ModelBinder(BinderType = typeof(TestFilterModelBinder))] TestFilter filter)
        {            
            return filter?.YearMonth?.Display ?? "unknown";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}