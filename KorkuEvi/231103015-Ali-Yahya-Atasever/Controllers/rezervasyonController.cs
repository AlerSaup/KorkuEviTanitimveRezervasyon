using _231103015_Ali_Yahya_Atasever.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _231103015_Ali_Yahya_Atasever.Controllers
{
    public class RezervasyonController : Controller
    {
        private readonly KorkueviContext _context;

        public RezervasyonController(KorkueviContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var rezervasyonlar = await _context.Rezervasyons.ToListAsync();
            return View(rezervasyonlar);
        }

        // GET: Rezervasyon/Create
        public async Task<IActionResult> Create()
        {
            var today = DateTime.Today;
            var rezervasyonluSaatler = await _context.Rezervasyons
                .Where(r => r.RezervasyonTarihi.Date == today)
                .Select(r => r.RezervasyonSaati)
                .ToListAsync();

			var saatler = _rezervasyonSaatleri.Select(saat => saat.ToString(@"hh\:mm")).ToList();
			ViewBag.RezervasyonSaatleri = saatler;


            return View();
        }


        private readonly List<TimeSpan> _rezervasyonSaatleri = new List<TimeSpan>
{
    new TimeSpan(10, 0, 0),
    new TimeSpan(11, 0, 0),
    new TimeSpan(12, 0, 0),
    new TimeSpan(13, 0, 0),
    new TimeSpan(14, 0, 0),
    new TimeSpan(15, 0, 0),
    new TimeSpan(16, 0, 0),
    new TimeSpan(17, 0, 0),
    new TimeSpan(18, 0, 0),
    new TimeSpan(19, 0, 0),
    new TimeSpan(20, 0, 0),
    new TimeSpan(21, 0, 0),
    new TimeSpan(22, 0, 0)
};



        // POST: Rezervasyon/Create
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Ad,Soyad,Telefon,RezervasyonTarihi,RezervasyonSaati")] Rezervasyon rezervasyon)
{
    if (ModelState.IsValid)
    {
        var mevcutRezervasyon = await _context.Rezervasyons
            .AnyAsync(r => r.RezervasyonTarihi.Date == rezervasyon.RezervasyonTarihi.Date 
                        && r.RezervasyonSaati == rezervasyon.RezervasyonSaati);

        if (mevcutRezervasyon)
        {
            ModelState.AddModelError("", "Bu saat için zaten bir rezervasyon alınmıştır.");
            return RedirectToAction("ErrorMessage", "Rezervasyon");
        }

        _context.Add(rezervasyon);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(rezervasyon);
}


        public IActionResult ErrorMessage()
        {
            return View("ErrorMessage");
        }
    }

}
