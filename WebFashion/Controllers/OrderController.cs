using WebFashion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebFashion.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        DBFashionEntities db = new DBFashionEntities();
        public ActionResult Index()
        {
            var order = db.OrderProes.OrderByDescending(x => x.ID);
            return View(order);
        }
        public ActionResult Details(int id)
        {

            return View(db.OrderProes.Where(s => s.ID == id).FirstOrDefault());
        }
        public ActionResult Partial_OrderDetail(int id)
        {
            var items = db.OrderDetails.Where(x => x.IDOrder == id).ToList();
            return PartialView(items);
        }
        public ActionResult Cancel(int ID)
        {
            OrderPro _order = db.OrderProes.Find(ID);
            _order.Status = 2;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}