using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Helpers;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class KhachHangsController : Controller
    {
        private readonly RestaurantContext _context;

        public KhachHangsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: KhachHangs
        public async Task<IActionResult> Index()
        {
          
           /* if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "login") == null)
            {             
                return View();
            }
            else
            {
                return RedirectToAction("index","Profile");
            }*/
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(string email, string password)
        {
            ViewBag.error = "";
            var kh = _context.KhachHangs.ToList();
            var data = _context.KhachHangs.Where(p => p.Email ==  email && p.Password == password).ToList();
            if(data.Count() > 0)
            {
                List<Login> khachhang = new List<Login>();
                khachhang.Add(new Login { khachHang = kh.Find(p=>p.Email == email)});
                SessionHelper.SetObjectAsJson(HttpContext.Session, "login", khachhang);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.error = "Đăng nhập thất bại";
                return View("index");

            }         
            
        }



        // GET: KhachHangs/Create
        public IActionResult Create()
        {        
            return View();
        }

        // POST: KhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKhachHang,TenKhachHang,Sdt,Email,Password,DiaChi,MaChucVu")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {

                var check = _context.KhachHangs.FirstOrDefault(s => s.Email == khachHang.Email);
                if (check == null)
                {
                    _context.Add(khachHang);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.error = "Email đã tồn tại";
                    return View();

                }
            }
            ViewData["MaChucVu"] = new SelectList(_context.ChucVus, "MaChucVu", "MaChucVu", khachHang.MaChucVu);
            return View(khachHang);
        }
        
        public async Task<IActionResult> Logout()
        {
            SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "login").Clear();
            List<Login> login = new List<Login>();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "login", login);
            return RedirectToAction("index", "KhachHangs");
        }



        private bool KhachHangExists(int id)
        {
            return _context.KhachHangs.Any(e => e.MaKhachHang == id);
        }
    }
}
