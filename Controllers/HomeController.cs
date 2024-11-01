using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Models
{
   
    public class HomeController : Controller
    {
        private readonly QLBANSACHEntities1 _context;

        // Constructor
        public HomeController()
        {
            _context = new QLBANSACHEntities1();
        }

        // GET: Home
        public ActionResult Index()
        {
            var newestBook = _context.SACHes.OrderByDescending(s => s.Ngaycapnhat).Take(5).ToList();
            return View(newestBook);
        }

        public ActionResult Categories()
        {
            var cate = _context.CHUDEs.ToList();
            return PartialView(cate);
        }

        public ActionResult Publisher()
        {
            var pub = _context.NHAXUATBANs.ToList();
            return PartialView(pub);
        }

        public ActionResult itemInCate(int id) 
        {
            var book = _context.SACHes.Where(s => s.MaCD == id).ToList();
            return View(book);
        }

        public ActionResult itemPub(int id)
        {
            var pub = _context.SACHes.Where(s => s.MaNXB == id).ToList();
            return View(pub);
        }

        public ActionResult Details(int id)
        {
            var book = _context.SACHes.Where(s => s.Masach == id).ToList();
            return View(book.Single());
        }

        //[HttpPost]
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}