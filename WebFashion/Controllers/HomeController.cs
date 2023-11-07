using PagedList;
using WebFashion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity;

namespace WebFashion.Controllers
{
    public class HomeController : Controller
    {
        public DBFashionEntities db = new DBFashionEntities();
        public ActionResult Index(string category, int? page, string SearchString, double min = double.MinValue, double max = double.MaxValue)
        {
            var products = db.Products.Include(p => p.Category);
            if (category == null)
            {
                products = db.Products.OrderByDescending(x => x.NamePro);
            }
            else
            {
                products = db.Products.OrderByDescending(x => x.ProductID).Where(x => x.Category == category);
            }

            // Tìm kiếm chuỗi truy vấn theo NamePro (SearchString)
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = db.Products.OrderByDescending(x => x.ProductID).Where(s => s.NamePro.Contains(SearchString.Trim()));
            }
            // Tìm kiếm chuỗi truy vấn theo đơn giá
            if (min >= 0 && max > 0)
            {
                products = db.Products.OrderByDescending(x => x.Price).Where(p => (double)p.Price >= min && (double)p.Price <= max);
            }

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            if (page == null) page = 1;
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult HomeCate(string category, int? page, string SearchString, double min = double.MinValue, double max = double.MaxValue)
        {

            var products = db.Products.Include(p => p.NamePro);
                products = db.Products.OrderByDescending(x => x.ProductID).Where(x => x.Category == category);

            if (!String.IsNullOrEmpty(SearchString))
            {
                products = db.Products.OrderByDescending(x => x.ProductID).Where(s => s.NamePro.Contains(SearchString.Trim()));
            }
            // Tìm kiếm chuỗi truy vấn theo đơn giá
            if (min >= 0 && max > 0)
            {
                products = db.Products.OrderByDescending(x => x.Price).Where(p => (double)p.Price >= min && (double)p.Price <= max);
            }
                
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            if (page == null) page = 1;

            return View(products.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Details(int? id)
        {
            Product product = db.Products.Find(id);
            if (id == null)
            {
                return new
                HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult SearchResult(string category, int? page, string SearchString, double min = double.MinValue, double max = double.MaxValue)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            if (page == null) page = 1;
            var products = db.Products.Include(p => p.Category);
            if (category == null)
            {
                products = db.Products.OrderByDescending(x => x.NamePro);
            }
            else
            {
                products = db.Products.OrderByDescending(x => x.ProductID).Where(x => x.Category == category);
            }
            // Tìm kiếm chuỗi truy vấn theo NamePro (SearchString)
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = db.Products.OrderByDescending(x => x.ProductID).Where(s => s.NamePro.Contains(SearchString.Trim()));
            }
            // Tìm kiếm chuỗi truy vấn theo đơn giá
            if (min >= 0 && max > 0)
            {
                products = db.Products.OrderByDescending(x => x.Price).Where(p => (double)p.Price >= min && (double)p.Price <= max);
            }
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult SearchPrice(string category, int? page, string SearchString, double min = double.MinValue, double max = double.MaxValue)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            if (page == null) page = 1;
            var products = db.Products.Include(p => p.Category);
            if (category == null)
            {
                products = db.Products.OrderByDescending(x => x.NamePro);
            }
            else
            {
                products = db.Products.OrderByDescending(x => x.ProductID).Where(x => x.Category == category);
            }
            // Tìm kiếm chuỗi truy vấn theo NamePro (SearchString)
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = db.Products.OrderByDescending(x => x.ProductID).Where(s => s.NamePro.Contains(SearchString.Trim()));
            }
            // Tìm kiếm chuỗi truy vấn theo đơn giá
            if (min >= 0 && max > 0)
            {
                products = db.Products.OrderByDescending(x => x.Price).Where(p => (double)p.Price >= min && (double)p.Price <= max);
            }
            return View(products.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}