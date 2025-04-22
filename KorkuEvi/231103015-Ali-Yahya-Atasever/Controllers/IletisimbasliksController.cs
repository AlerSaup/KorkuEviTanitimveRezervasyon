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
    public class IletisimbasliksController : Controller
    {
        private readonly KorkueviContext _context;

        public IletisimbasliksController(KorkueviContext context)
        {
            _context = context;
        }

        // GET: Iletisimbasliks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Iletisimbasliks.ToListAsync());
        }

        // GET: Iletisimbasliks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iletisimbaslik = await _context.Iletisimbasliks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iletisimbaslik == null)
            {
                return NotFound();
            }

            return View(iletisimbaslik);
        }

        // GET: Iletisimbasliks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Iletisimbasliks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Iletisimbaslik1")] Iletisimbaslik iletisimbaslik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iletisimbaslik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iletisimbaslik);
        }

        // GET: Iletisimbasliks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iletisimbaslik = await _context.Iletisimbasliks.FindAsync(id);
            if (iletisimbaslik == null)
            {
                return NotFound();
            }
            return View(iletisimbaslik);
        }

        // POST: Iletisimbasliks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Iletisimbaslik1")] Iletisimbaslik iletisimbaslik)
        {
            if (id != iletisimbaslik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iletisimbaslik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IletisimbaslikExists(iletisimbaslik.Id))
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
            return View(iletisimbaslik);
        }

        // GET: Iletisimbasliks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iletisimbaslik = await _context.Iletisimbasliks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iletisimbaslik == null)
            {
                return NotFound();
            }

            return View(iletisimbaslik);
        }

        // POST: Iletisimbasliks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iletisimbaslik = await _context.Iletisimbasliks.FindAsync(id);
            if (iletisimbaslik != null)
            {
                _context.Iletisimbasliks.Remove(iletisimbaslik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IletisimbaslikExists(int id)
        {
            return _context.Iletisimbasliks.Any(e => e.Id == id);
        }
    }
}
