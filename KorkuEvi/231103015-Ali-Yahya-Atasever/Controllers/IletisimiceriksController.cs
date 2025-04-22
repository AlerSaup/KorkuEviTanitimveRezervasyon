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
    public class IletisimiceriksController : Controller
    {
        private readonly KorkueviContext _context;

        public IletisimiceriksController(KorkueviContext context)
        {
            _context = context;
        }

        // GET: Iletisimiceriks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Iletisimiceriks.ToListAsync());
        }

        // GET: Iletisimiceriks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iletisimicerik = await _context.Iletisimiceriks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iletisimicerik == null)
            {
                return NotFound();
            }

            return View(iletisimicerik);
        }

        // GET: Iletisimiceriks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Iletisimiceriks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Iletisimitel,Iletisimadres")] Iletisimicerik iletisimicerik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iletisimicerik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iletisimicerik);
        }

        // GET: Iletisimiceriks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iletisimicerik = await _context.Iletisimiceriks.FindAsync(id);
            if (iletisimicerik == null)
            {
                return NotFound();
            }
            return View(iletisimicerik);
        }

        // POST: Iletisimiceriks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Iletisimitel,Iletisimadres")] Iletisimicerik iletisimicerik)
        {
            if (id != iletisimicerik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iletisimicerik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IletisimicerikExists(iletisimicerik.Id))
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
            return View(iletisimicerik);
        }

        // GET: Iletisimiceriks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iletisimicerik = await _context.Iletisimiceriks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iletisimicerik == null)
            {
                return NotFound();
            }

            return View(iletisimicerik);
        }

        // POST: Iletisimiceriks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iletisimicerik = await _context.Iletisimiceriks.FindAsync(id);
            if (iletisimicerik != null)
            {
                _context.Iletisimiceriks.Remove(iletisimicerik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IletisimicerikExists(int id)
        {
            return _context.Iletisimiceriks.Any(e => e.Id == id);
        }
    }
}
