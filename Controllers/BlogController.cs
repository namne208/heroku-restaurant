using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class BlogController : Controller
    {

        private readonly RestaurantContext _context;

        public BlogController(RestaurantContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var blog = _context.Blogs.ToList();
            return View(blog);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
               
                .FirstOrDefaultAsync(m => m.MaBlog == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }
    }
}
