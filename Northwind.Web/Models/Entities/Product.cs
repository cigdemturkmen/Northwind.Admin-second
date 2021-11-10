using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models.Entities
{
    public class Product: BaseClass
    {
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitInStock { get; set; }

        public bool Discontinued { get; set; }


        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}