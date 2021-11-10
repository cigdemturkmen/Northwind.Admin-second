using Northwind.Web.Models.Entities;
using Northwind.Web.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly NorthwindDbContext _db; // field

        public AuthController() // ctor tab tab
        {
            // IOC Container, Ninject vb DI(dependency injection) 3rd dll
            _db = new NorthwindDbContext();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // dbye user'ı kaydediyoruz

            User yeniKullanici = new User()
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email,
                Password = model.Password,
                CreatedDate = DateTime.Now,
                IsActive = true,
                CreatedById = -1
            };

            _db.Users.Add(yeniKullanici);

            var sonuc = _db.SaveChanges();

            if (sonuc > 0)
            {
                TempData["Message"] = "Kullanıcı eklendi!";
                return RedirectToAction("Login");
            }

            TempData["Message"] = "Kullanıcı eklenemedi!";
            return View(model);
        }

        public ActionResult Login()
        {
            var cerez = Request.Cookies.Get("loginCookie");
            if (cerez != null)
            {
                var email = cerez.Values.Get("email");
                var psw = cerez.Values.Get("password");

                var lvm = new LoginViewModel()
                {
                    Email = email,
                    Password = psw,
                    RememberMe = true
                };
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var kullanici = _db.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password && x.IsActive);

            if (kullanici != null)
            {
                // session
                Session.Add("LoginBilgileri", kullanici);

                //cookie
                if (model.RememberMe)
                {
                    var cerez = new HttpCookie("loginCookie");
                    cerez.Expires = DateTime.Now.AddDays(2);
                    cerez.Values.Add("email", kullanici.Email);
                    cerez.Values.Add("password", kullanici.Password);
                    Response.Cookies.Add(cerez);
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Kullanıcı bulunamadı. Bilgilerinizi kontrol ediniz";             
            }
            return View(model);
        }


        public ActionResult Logout()
        {
            Session.Remove("LoginBilgileri");

            return RedirectToAction("Login");
        }
    }
}