using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models.Entities
{
    public class BaseClass
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedById { get; set; }
        public int? UpdatedById { get; set; }
        public bool IsActive { get; set; } // soft delete yapmak için ekledik
       
        // value types(stack), int,bool,decimal,Datetime,struct
        // reference types(heap), string, class
    }
}