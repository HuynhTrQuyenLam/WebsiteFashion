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
    public class ProductController : Controller
    {
        private DBFashionEntities db = new DBFashionEntities();

        public ActionResult Index(string category)
        {
            if (category == null)
            {
                var productList = db.Products.OrderByDescending(x => x.NamePro);
                return View(productList);
            }
            else
            {
                var productList = db.Products.OrderByDescending(x => x.NamePro).Where(p => p.Category == category);
                return View(productList);
            }
        }

        ///// Detail /////
        public ActionResult Details(int id)
        {
            var product = db.Products.FirstOrDefault(pr => pr.ProductID == id);
            return View(product);
        }

        public ActionResult Create()
        {
            List<Category> list = db.Categories.ToList();
            ViewBag.listCategory = new SelectList(list, "IDCate", "NameCate");
            Product pro = new Product();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            List<Category> list = db.Categories.ToList();
            try
            {
                if (pro.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
                    string extent = Path.GetExtension(pro.UploadImage.FileName);
                    filename = filename + extent;
                    pro.ImagePro = filename;
                    pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), filename));

                }
                ViewBag.listCategory = new SelectList(list, "IDCate", "NameCate", 1);
                db.Products.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(db.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                product = db.Products.Where(s => s.ProductID == id).FirstOrDefault();
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Có sai sót! Xin kiểm tra lại thông tin");
            }
        }


    }
}