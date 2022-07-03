using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class HoaDonsController : Controller
    {
        private readonly RestaurantContext _context;

        public HoaDonsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: HoaDons
        public async Task<IActionResult> Index(int id)
        {      
            var hoadon = _context.HoaDons.Include(c => c.MaThanhToanNavigation).Include(c => c.MaVanChuyenNavigation).Where(p => p.MaKhachHang == id).ToList();        
            return View(hoadon);
        }

        // GET: HoaDons/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cthoaDon =  _context.ChiTietHoaDons.Include(c => c.MaSanPhamNavigation).Include(c => c.MaHoaDonNavigation).Where(m => m.MaHoaDon == id).ToList();
            if (cthoaDon == null)
            {
                return NotFound();
            }
            return View(cthoaDon);
        }

        
        

        private bool HoaDonExists(int id)
        {
            return _context.HoaDons.Any(e => e.MaHoaDon == id);
        }
    }
}
