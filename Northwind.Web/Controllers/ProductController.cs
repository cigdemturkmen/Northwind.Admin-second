using Northwind.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Northwind.Web.Models.ViewModel;
using Northwind.Web.Filters;

namespace Northwind.Web.Controllers
{
    [Auth]
    public class ProductController : Controller
    {
        private readonly NorthwindDbContext _db;

        public ProductController()
        {
            _db = new NorthwindDbContext();
        }
        public ActionResult List()
        {
            var products = _db.Products.Include(x => x.Category).Where(x => x.IsActive).Select(x => new ProductViewModel()
            {
                Id = x.Id,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                UnitInStock = x.UnitInStock,
                Discontinued = x.Discontinued,
                CategoryName = x.Category.CategoryName,
            }).ToList();

            return View(products);
        }

        public ActionResult Add()
        {
            //ddl select item tipinde veri istediği için to list demek yetmedi. onu selectitem'a çevirmek gerekti.
            ViewBag.Categories = _db.Categories.Select(x => new SelectListItem() 
            {
                Text= x.CategoryName,
                Value = x.Id.ToString()
            }).ToList();

           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _db.Categories.Select(x => new SelectListItem()
                {
                    Text = x.CategoryName,
                    Value = x.Id.ToString()
                }).ToList();
                return View(model);
            }

            Models.Entities.User currentUser = null;
            if (Session["LoginBilgileri"] != null)
            {
                currentUser = (Models.Entities.User)Session["LoginBilgileri"];
            }

            var entity = new Product()
            {
                CategoryId = model.CategoryId,
                ProductName = model.ProductName,
                UnitInStock = model.UnitInStock,
                UnitPrice = model.UnitPrice,
                IsActive = true,
                Discontinued = model.Discontinued,
                CreatedDate = DateTime.Now,
                CreatedById = (int)currentUser?.Id   /*!!!!!!!nullable yapma!!!!!!*/
            };

            _db.Products.Add(entity);

            var sonuc = _db.SaveChanges();

            if (sonuc > 0)
            {
                return RedirectToAction("List");
            }

            ViewBag.Categories = _db.Categories.Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.Id.ToString()
            }).ToList();

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            

            var product = _db.Products.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                var pvm = new ProductViewModel()
                {

                };

                ViewBag.Categories = _db.Categories.Select(x => new SelectListItem()
                {
                    Text = x.CategoryName,
                    Value = x.Id.ToString()
                }).ToList();

                return View(pvm);
            }

            //listeye redirect ederken tempdata ile ürün bulunamadı uyarısı verilsibn.

            TempData["Message"] = "product not found";

            return RedirectToAction("List");
           
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == model.Id);

            if (product != null)
            {
                product.CategoryId = model.CategoryId;
                product.ProductName = model.ProductName;
                product.UnitInStock = model.UnitInStock;
                product.UnitPrice = model.UnitPrice;
                product.Discontinued = model.Discontinued;
                product.UpdatedDate = DateTime.Now;

                Models.Entities.User currentUser = null;
                if (Session["LoginBilgileri"] != null)
                {
                    currentUser = (Models.Entities.User)Session["LoginBilgileri"];
                }

                product.UpdatedById = currentUser.Id;

                _db.Products.Add(product);

                var sonuc = _db.SaveChanges();

                if (sonuc > 0)
                {
                    return RedirectToAction("List");
                }
            }

            ViewBag.Categories = _db.Categories.Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.Id.ToString()
            }).ToList();

            return View(model);
            
        }

        public ActionResult Delete(int id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                //_db.Products.Remove(product); // hard delete

                product.IsActive = false; // soft delete
                product.UpdatedDate = DateTime.Now;

                Models.Entities.User currentUser = null;
                if (Session["LoginBilgileri"] != null)
                {
                    currentUser = (Models.Entities.User)Session["LoginBilgileri"];
                }

                product.UpdatedById = currentUser.Id;

                var sonuc = _db.SaveChanges();

                if (sonuc > 0)
                {
                    return RedirectToAction("List");
                }
            }

            TempData["Message"] = "Silme işlemi yapılamadı";
            return RedirectToAction("List");

        }
    }
}