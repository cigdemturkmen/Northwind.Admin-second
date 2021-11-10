using Northwind.Web.Filters;
using Northwind.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Web.Controllers
{
    [Auth]
    public class HomeController : Controller
    {
        private readonly NorthwindDbContext _db; // field

        public HomeController() // ctor tab tab
        {
            // IOC Container, Ninject vb DI(dependency injection) 3rd dll
            _db = new NorthwindDbContext();
        }
        public ActionResult Index()
        {
            // ddl olarak category'leri doldurmak
            ViewBag.Categories = _db.Categories.Select(x =>
            new SelectListItem { 
                Text = x.CategoryName, 
                Value = x.Id.ToString() 
            }).ToList();

            return View();
        }

        // CategoryController ve ProductController oluşturunuz,
        // Category, Product entitylerini oluşturunuz
        // Dbye bu 2 entity'i ekleyiniz(migration)
        // Add, Edit, Delete, List işlemlerini yapınız.
    }
}