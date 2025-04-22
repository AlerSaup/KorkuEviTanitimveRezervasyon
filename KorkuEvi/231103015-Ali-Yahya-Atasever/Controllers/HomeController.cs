using _231103015_Ali_Yahya_Atasever.Database;
using _231103015_Ali_Yahya_Atasever.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _231103015_Ali_Yahya_Atasever.Controllers
{
    public class HomeController : Controller
    {
        KorkueviContext korkuevi = new KorkueviContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var anasayfa = korkuevi.Anasayfas.ToList();
            return View(anasayfa);
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
