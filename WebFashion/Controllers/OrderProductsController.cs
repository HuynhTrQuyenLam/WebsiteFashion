using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFashion.Models;

namespace WebFashion.Controllers
{
    public class OrderProductsController : Controller
    {
        // GET: OrderProducts
        private DBFashionEntities db = new DBFashionEntities();
        public ActionResult Index()
        {
            var orderproes = db.OrderProes.ToList();
            return View(orderproes);
        }
        public ActionResult Detail(int id)
        {
            return View(db.OrderProes.Where(s => s.ID == id).FirstOrDefault());
        }
        public ActionResult Partial_OrderDetail(int id)
        {
            var items = db.OrderDetails.Where(x => x.IDOrder == id).ToList();
            return PartialView(items);
        }
    }
}