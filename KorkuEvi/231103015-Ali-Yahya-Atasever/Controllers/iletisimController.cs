using Microsoft.AspNetCore.Mvc;
using _231103015_Ali_Yahya_Atasever.Database;
using _231103015_Ali_Yahya_Atasever.ViewModels; // ViewModel'i kullanmak için ekle

namespace _231103015_Ali_Yahya_Atasever.Controllers
{
    public class iletisimController : Controller
    {
        KorkueviContext korkuevi = new KorkueviContext();
        public IActionResult Index()
        {
			var iletisimbasliklar = korkuevi.Iletisimbasliks.ToList();
			var iletisimicerikler = korkuevi.Iletisimiceriks.ToList();

			// ViewModel'i doldur
			var viewModel = new iletisimViewModel
			{
				Iletisimbasliklar = iletisimbasliklar,
				Iletisimicerikler = iletisimicerikler
			};
            return View(viewModel);
        }
    }
}
