using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;
using X.PagedList.Mvc.Core;
using Microsoft.AspNetCore.Cors.Infrastructure;

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Restaurant.Controllers
{
    public class ProductController : Controller
    {

       
        private readonly RestaurantContext _context;
        //private readonly  GioHangService _gioHangService;

        public ProductController(RestaurantContext context)
        {
            _context = context;
            //_gioHangService = gioHangService;

        }
        public async Task<IActionResult> Index(string searchString, int id, int page = 0)
        {
            var id2 = id > 0 ? id : -1;
            //var sanpham =_context.SanPhams.OrderBy(x=> Guid.NewGuid()).Take(_context.SanPhams.Count()).ToList().Skip((page - 1) * 8).Take(8
            var sanpham =_context.SanPhams.OrderBy(x=> Guid.NewGuid()).Take(_context.SanPhams.Count()).ToList().Skip((page - 1) * 8).Take(8);
            var lsp = _context.LoaiSanPhams.ToList();

            if (id2 != -1)
            {
                sanpham = _context.SanPhams.Where(m => m.MaLoaiSanPham == id2).ToList().Skip((page - 1) * 8).Take(8);
               
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                sanpham = _context.SanPhams.Where(b => b.TenSanPham.ToLower().Contains(searchString)).ToList();
            }

            // sanpham = _context.SanPhams.Include(s => s.MaLoaiSanPhamNavigation).Include(s => s.MaThucDonNavigation);
            ViewBag.Count = 0;
            var n = (float)(_context.SanPhams.ToList().Count() / 8 + 1);
            //ViewBag.PageSize = Math.Round((float)n);
            ViewBag.PageSize = n;
            ViewBag.Page = page;        
            ViewBag.DanhMuc = lsp;
            return View(sanpham);

            //return View(await restaurantContext.ToListAsync());
        }
       

        // GET: SanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.MaLoaiSanPhamNavigation)
                .Include(s => s.MaThucDonNavigation)
                .FirstOrDefaultAsync(m => m.MaSanPham == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }
        
        
       
    }
}
