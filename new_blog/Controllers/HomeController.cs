using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using new_blog.Models;
using Microsoft.AspNetCore.Http;

namespace new_blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostService db;
        public HomeController(PostService context)
        {
            db = context;
        }
        public async Task<IActionResult> Index(FilterViewModel filter)
        {
            var phones = await db.GetPosts(filter.MinPrice, filter.MaxPrice, filter.Name);
            var model = new IndexViewModel { Posts = phones, Filter = filter };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Post p)
        {
            if (ModelState.IsValid)
            {
                await db.Create(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
}
