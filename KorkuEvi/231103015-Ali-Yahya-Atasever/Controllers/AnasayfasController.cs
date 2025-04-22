using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _231103015_Ali_Yahya_Atasever.Database;

namespace _231103015_Ali_Yahya_Atasever.Controllers
{
    public class AnasayfasController : Controller
    {
        private readonly KorkueviContext _context;

        public AnasayfasController(KorkueviContext context)
        {
            _context = context;
        }

        // GET: Anasayfas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anasayfas.ToListAsync());
        }

        // GET: Anasayfas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anasayfa = await _context.Anasayfas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anasayfa == null)
            {
                return NotFound();
            }

            return View(anasayfa);
        }

        // GET: Anasayfas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anasayfas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Anasayfabaslik,Anasayfaicerik,Anasayfaresim")] Anasayfa anasayfa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anasayfa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anasayfa);
        }

        // GET: Anasayfas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anasayfa = await _context.Anasayfas.FindAsync(id);
            if (anasayfa == null)
            {
                return NotFound();
            }
            return View(anasayfa);
        }

        // POST: Anasayfas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Anasayfabaslik,Anasayfaicerik,Anasayfaresim")] Anasayfa anasayfa)
        {
            if (id != anasayfa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anasayfa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnasayfaExists(anasayfa.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(anasayfa);
        }

        // GET: Anasayfas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anasayfa = await _context.Anasayfas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anasayfa == null)
            {
                return NotFound();
            }

            return View(anasayfa);
        }

        // POST: Anasayfas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anasayfa = await _context.Anasayfas.FindAsync(id);
            if (anasayfa != null)
            {
                _context.Anasayfas.Remove(anasayfa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnasayfaExists(int id)
        {
            return _context.Anasayfas.Any(e => e.Id == id);
        }
    }
}
