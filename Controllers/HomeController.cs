using Bio.Models.message;
using Bio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Bio.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        NorthwindEntities1 db = new NorthwindEntities1();
        NorthwindEntitiesMessage dbm = new NorthwindEntitiesMessage();
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Index()
        {
            var model = db.ToDo.ToList();
            return View(model);
            
        }

        public ActionResult Skills()
        {
            return View();

        }


        [HttpPost]
        public ActionResult Contact(replies mess)
        {
            dbm.replies.Add(mess);

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(ToDo task)
        {
            if (task.ID == 0) //for insert
            {
                db.ToDo.Add(task);
            }
            else
            {
                var updateData=db.ToDo.Find(task.ID);
                if(updateData==null)
                {
                    return HttpNotFound();
                }
                updateData.TaskName = task.TaskName;
            }

            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Update(int id)
        {
            var model = db.ToDo.Find(id);
           if (model==null)
            {
                return HttpNotFound();

            }
            return View("Yeni", model);

        }

        public ActionResult Delete(int id)
        {
            var delete = db.ToDo.Find(id);
            if (delete == null)
            {

                return HttpNotFound();
            }
            db.ToDo.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}