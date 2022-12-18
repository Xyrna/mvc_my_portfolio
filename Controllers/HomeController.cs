using Bio.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bio.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            var model = db.Orders.ToList();
            return View(model);
            
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            var model = db.Order_Details.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Orders ord)
        {
            db.Orders.Add(ord); 
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}