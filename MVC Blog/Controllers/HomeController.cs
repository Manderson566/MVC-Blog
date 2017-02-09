using MVC_Blog.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace MVC_Blog.Controllers
{
    public class HomeController : Controller
    {
        public BlogContext db = new BlogContext();

        public ActionResult Index()
        {
            ViewBag.AllBlogs = db.Blogs.OrderByDescending(b => b.Created).ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            db.Blogs.Add(blog);
            blog.Created = DateTime.Now;
            if (blog == null)
            {
                blog = new Blog();
            }
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult ReadPost(int Id)
        {
            Blog blog = db.Blogs.Find(Id);
            return View(blog);

        }
    }
}