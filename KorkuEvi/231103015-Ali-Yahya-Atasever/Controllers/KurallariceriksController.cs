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
    public class KurallariceriksController : Controller
    {
        private readonly KorkueviContext _context;

        public KurallariceriksController(KorkueviContext context)
        {
            _context = context;
        }

        // GET: Kurallariceriks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kurallariceriks.ToListAsync());
        }

        // GET: Kurallariceriks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurallaricerik = await _context.Kurallariceriks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kurallaricerik == null)
            {
                return NotFound();
            }

            return View(kurallaricerik);
        }

        // GET: Kurallariceriks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kurallariceriks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kuralicerik")] Kurallaricerik kurallaricerik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kurallaricerik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kurallaricerik);
        }

        // GET: Kurallariceriks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurallaricerik = await _context.Kurallariceriks.FindAsync(id);
            if (kurallaricerik == null)
            {
                return NotFound();
            }
            return View(kurallaricerik);
        }

        // POST: Kurallariceriks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kuralicerik")] Kurallaricerik kurallaricerik)
        {
            if (id != kurallaricerik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kurallaricerik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KurallaricerikExists(kurallaricerik.Id))
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
            return View(kurallaricerik);
        }

        // GET: Kurallariceriks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurallaricerik = await _context.Kurallariceriks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kurallaricerik == null)
            {
                return NotFound();
            }

            return View(kurallaricerik);
        }

        // POST: Kurallariceriks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kurallaricerik = await _context.Kurallariceriks.FindAsync(id);
            if (kurallaricerik != null)
            {
                _context.Kurallariceriks.Remove(kurallaricerik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KurallaricerikExists(int id)
        {
            return _context.Kurallariceriks.Any(e => e.Id == id);
        }
    }
}
