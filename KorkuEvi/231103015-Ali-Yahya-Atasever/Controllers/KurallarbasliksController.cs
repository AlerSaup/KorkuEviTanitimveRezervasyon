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
    public class KurallarbasliksController : Controller
    {
        private readonly KorkueviContext _context;

        public KurallarbasliksController(KorkueviContext context)
        {
            _context = context;
        }

        // GET: Kurallarbasliks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kurallarbasliks.ToListAsync());
        }

        // GET: Kurallarbasliks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurallarbaslik = await _context.Kurallarbasliks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kurallarbaslik == null)
            {
                return NotFound();
            }

            return View(kurallarbaslik);
        }

        // GET: Kurallarbasliks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kurallarbasliks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kurallarbaslik1")] Kurallarbaslik kurallarbaslik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kurallarbaslik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kurallarbaslik);
        }

        // GET: Kurallarbasliks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurallarbaslik = await _context.Kurallarbasliks.FindAsync(id);
            if (kurallarbaslik == null)
            {
                return NotFound();
            }
            return View(kurallarbaslik);
        }

        // POST: Kurallarbasliks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kurallarbaslik1")] Kurallarbaslik kurallarbaslik)
        {
            if (id != kurallarbaslik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kurallarbaslik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KurallarbaslikExists(kurallarbaslik.Id))
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
            return View(kurallarbaslik);
        }

        // GET: Kurallarbasliks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurallarbaslik = await _context.Kurallarbasliks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kurallarbaslik == null)
            {
                return NotFound();
            }

            return View(kurallarbaslik);
        }

        // POST: Kurallarbasliks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kurallarbaslik = await _context.Kurallarbasliks.FindAsync(id);
            if (kurallarbaslik != null)
            {
                _context.Kurallarbasliks.Remove(kurallarbaslik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KurallarbaslikExists(int id)
        {
            return _context.Kurallarbasliks.Any(e => e.Id == id);
        }
    }
}
