using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomethingHere.Web.UI.Models
{
    public class CartInfoResponse
    {
        public decimal TotalPrice { get; set; }
        public int ItemCount { get; set; }
    }
}