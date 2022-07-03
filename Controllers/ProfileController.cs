using Microsoft.AspNetCore.Mvc;
using Restaurant.Helpers;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {

            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "login");
                if(login.Count() > 0)
                {
                    return View(login);
                }
                else
                {
                    return RedirectToAction("index", "KhachHangs");
                }
                
            }
            else
            {
                return RedirectToAction("index", "KhachHangs");
            }
        }
        
    }
}
