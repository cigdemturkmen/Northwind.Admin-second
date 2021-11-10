using Northwind.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitInStock { get; set; }

        public bool Discontinued { get; set; }


        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}