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
    public class GopiesController : Controller
    {
        private readonly RestaurantContext _context;

        public GopiesController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Admin/Gopies
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.Gopies.Include(g => g.MaKhachHangNavigation);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: Admin/Gopies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gopY = await _context.Gopies
                .Include(g => g.MaKhachHangNavigation)
                .FirstOrDefaultAsync(m => m.MaGopY == id);
            if (gopY == null)
            {
                return NotFound();
            }

            return View(gopY);
        }

        // GET: Admin/Gopies/Create
        public IActionResult Create()
        {
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "DiaChi");
            return View();
        }

        // POST: Admin/Gopies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaGopY,NoiDung,TinhTrang,MaKhachHang")] GopY gopY)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gopY);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "DiaChi", gopY.MaKhachHang);
            return View(gopY);
        }

        // GET: Admin/Gopies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gopY = await _context.Gopies.FindAsync(id);
            if (gopY == null)
            {
                return NotFound();
            }
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "DiaChi", gopY.MaKhachHang);
            return View(gopY);
        }

        // POST: Admin/Gopies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaGopY,NoiDung,TinhTrang,MaKhachHang")] GopY gopY)
        {
            if (id != gopY.MaGopY)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gopY);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GopYExists(gopY.MaGopY))
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
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "DiaChi", gopY.MaKhachHang);
            return View(gopY);
        }

        // GET: Admin/Gopies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gopY = await _context.Gopies
                .Include(g => g.MaKhachHangNavigation)
                .FirstOrDefaultAsync(m => m.MaGopY == id);
            if (gopY == null)
            {
                return NotFound();
            }

            return View(gopY);
        }

        // POST: Admin/Gopies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gopY = await _context.Gopies.FindAsync(id);
            _context.Gopies.Remove(gopY);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GopYExists(int id)
        {
            return _context.Gopies.Any(e => e.MaGopY == id);
        }
    }
}
