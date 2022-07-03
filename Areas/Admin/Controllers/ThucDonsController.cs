using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThucDonsController : Controller
    {
        private readonly RestaurantContext _context;

        public ThucDonsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Admin/ThucDons
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThucDons.ToListAsync());
        }

        // GET: Admin/ThucDons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thucDon = await _context.ThucDons
                .FirstOrDefaultAsync(m => m.MaThucDon == id);
            if (thucDon == null)
            {
                return NotFound();
            }

            return View(thucDon);
        }

        // GET: Admin/ThucDons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ThucDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaThucDon,TenThucDon")] ThucDon thucDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thucDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thucDon);
        }

        // GET: Admin/ThucDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thucDon = await _context.ThucDons.FindAsync(id);
            if (thucDon == null)
            {
                return NotFound();
            }
            return View(thucDon);
        }

        // POST: Admin/ThucDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaThucDon,TenThucDon")] ThucDon thucDon)
        {
            if (id != thucDon.MaThucDon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thucDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThucDonExists(thucDon.MaThucDon))
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
            return View(thucDon);
        }

        // GET: Admin/ThucDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thucDon = await _context.ThucDons
                .FirstOrDefaultAsync(m => m.MaThucDon == id);
            if (thucDon == null)
            {
                return NotFound();
            }

            return View(thucDon);
        }

        // POST: Admin/ThucDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thucDon = await _context.ThucDons.FindAsync(id);
            _context.ThucDons.Remove(thucDon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThucDonExists(int id)
        {
            return _context.ThucDons.Any(e => e.MaThucDon == id);
        }
    }
}
