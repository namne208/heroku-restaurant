using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.Helpers;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class CartController : Controller
    {
        private readonly RestaurantContext _context;


        public CartController(RestaurantContext context)
        {
            _context = context;


        }
        public async Task<IActionResult> Index()
        {
            var sp = _context.SanPhams.ToList();
            
            if (SessionHelper.GetObjectFromJson<List<GioHang>>(HttpContext.Session, "cart") == null)
            {
                List<GioHang> cart = new List<GioHang>();               
                return View(cart);
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<GioHang>>(HttpContext.Session, "cart").ToList();
                return View(cart);
            }
            
        }
        public async Task<IActionResult> Buy(int id)
        {
            var sp = _context.SanPhams.ToList();
            if (SessionHelper.GetObjectFromJson<List<GioHang>>(HttpContext.Session, "cart") == null)
            {
                List<GioHang> cart = new List<GioHang>();
                cart.Add(new GioHang { SanPham = sp.Find(p => p.MaSanPham == id), SoLuong = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<GioHang> cart = SessionHelper.GetObjectFromJson<List<GioHang>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].SoLuong++;
                }
                else
                {
                    cart.Add(new GioHang { SanPham = sp.Find(p => p.MaSanPham == id), SoLuong = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Remove(int id)
        {
            List<GioHang> cart = SessionHelper.GetObjectFromJson<List<GioHang>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<GioHang> cart = SessionHelper.GetObjectFromJson<List<GioHang>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].SanPham.MaSanPham.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public async Task<IActionResult> CheckOut()
        {
            var cart = SessionHelper.GetObjectFromJson<List<GioHang>>(HttpContext.Session, "cart");
            var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "login");
            if(login == null  )
            {
                
                return RedirectToAction("Index", "KhachHangs");
                
               
            }
            else
            {
                return View(login);
            }

          
        }
        [HttpPost]
        public async Task<IActionResult> thanhtoan(string email, string diachi, string sdt)
        {
            var cart = SessionHelper.GetObjectFromJson<List<GioHang>>(HttpContext.Session, "cart");
            var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "login");
            int tien = 35000;
            int soluong = 0;
            int giamgia = 0;
            foreach(var i in cart)
            {
                giamgia = ((int?)i.SanPham.Tien).Value - (((int?)i.SanPham.Tien).Value * ((int?)i.SanPham.GiamGia).Value / 100);
                tien = tien + giamgia;
                soluong = soluong + i.SoLuong;
            }
           
            var kh = _context.KhachHangs.First(p => p.Email == email);
            HoaDon hd = new HoaDon();
            hd.MaKhachHang = kh.MaKhachHang;
            hd.NgayLap = DateTime.Now;
            hd.TongTien = tien;
            hd.SoLuong = soluong;
            hd.DiaChi = diachi;
            hd.Sdt = sdt;
            hd.MaThanhToan = 1;
            hd.MaVanChuyen = 1;
            _context.HoaDons.Add(hd);
            _context.SaveChanges();

            int MaHoadon = hd.MaHoaDon;
            List<ChiTietHoaDon> chitiethoadon = new List<ChiTietHoaDon>();         
            foreach(var item in cart)
            {
                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd.MaHoaDon = MaHoadon;
                cthd.MaSanPham = item.SanPham.MaSanPham;
                cthd.SoLuong = item.SoLuong;
                cthd.TongTien = ((int?)item.SanPham.Tien).Value - (((int?)item.SanPham.Tien).Value * ((int?)item.SanPham.GiamGia).Value / 100);
                chitiethoadon.Add(cthd);
            }
            _context.ChiTietHoaDons.AddRange(chitiethoadon);
            _context.SaveChanges();
             SessionHelper.GetObjectFromJson<List<GioHang>>(HttpContext.Session, "cart").Clear();
            List<GioHang> gioHangs = new List<GioHang>();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", gioHangs);          
            return RedirectToAction("Index", "Home");
        }


    }
}
