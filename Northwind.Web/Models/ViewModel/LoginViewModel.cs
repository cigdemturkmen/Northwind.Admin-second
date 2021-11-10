using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        [EmailAddress(ErrorMessage = "ornek@mail.com şeklinde giriniz.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Zorunlu Alan")]
        [StringLength(12, ErrorMessage = "Max 12, Min 4 giriş yapılabilir.", MinimumLength = 4)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }
    }
}