using Northwind.Web.Models.Entities;
using Northwind.Web.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Web.Controllers
{
    public class CategoryController : Controller
    {
        /*
         Entity'leri direkt olarak kullanmak yerine view model yapılması tercih edilir.
             */

        private readonly NorthwindDbContext _db;
        public CategoryController()
        {
            _db = new NorthwindDbContext();
        }

        public ActionResult List()
        {
            // Category entity --> CategoryViewModel
            var categories = _db.Categories
                .Select(x => new CategoryViewModel()
                {
                    CategoryId = x.Id,
                    CategoryName = x.CategoryName,
                    Description = x.Description
                })
                .ToList();

            return View(categories);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CategoryViewModel model)
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}