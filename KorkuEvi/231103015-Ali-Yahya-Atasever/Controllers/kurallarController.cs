using _231103015_Ali_Yahya_Atasever.Database;
using _231103015_Ali_Yahya_Atasever.ViewModels; // ViewModel'i kullanmak için ekle
using Microsoft.AspNetCore.Mvc;

namespace _231103015_Ali_Yahya_Atasever.Controllers
{
    public class kurallarController : Controller
    {
		KorkueviContext korkuevi = new KorkueviContext();

		public IActionResult Index()
		{
			// Verileri al
			var kurallarbasliklar = korkuevi.Kurallarbasliks.ToList();
			var kurallaricerikler = korkuevi.Kurallariceriks.ToList();

			// ViewModel'i doldur
			var viewModel = new KurallarViewModel
			{
				KurallarBasliklar = kurallarbasliklar,
				KurallarIcerikler = kurallaricerikler
			};

			return View(viewModel); // ViewModel'i view'a gönder
		}
	}
}
