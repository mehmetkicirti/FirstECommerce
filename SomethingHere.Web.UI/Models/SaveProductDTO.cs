using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SomethingHere.Web.UI.Models
{
    public class SaveProductDTO
    {
        [Required(ErrorMessage ="Name is Required")]
        [MinLength(3,ErrorMessage ="Product name cannot be shorter than 3 char")]
        public string Name { get; set; }
        [Range(1,1000000,ErrorMessage ="Price is invalid")]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public int BrandId { get; set; }
        public int SupplierId { get; set; }
        public string IsActive { get; set; }
    }
}