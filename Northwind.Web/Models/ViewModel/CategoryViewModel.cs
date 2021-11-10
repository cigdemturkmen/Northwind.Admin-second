using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models.ViewModel
{
    public class CategoryViewModel
    {
        // POCO, VM, DTO(data transfer object)
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(15, ErrorMessage = "Kategori adı en fazla 15 karakter olabilir.", MinimumLength = 2)]
        public string CategoryName { get; set; }


        [StringLength(500, ErrorMessage = "Kategori açıklaması en fazla 500 karakter olabilir.")]
        public string Description { get; set; }
    }
}