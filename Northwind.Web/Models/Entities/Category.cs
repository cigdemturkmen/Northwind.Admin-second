using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models.Entities
{
    public class Category : BaseClass
    {
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}