using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomethingHere.Web.UI.Models
{ //array resize ile boyutu belli olması icin kullanılır
    public class SaveImageDTO
    {
        //public SaveImageDTO()
        //{
        //    Array.Resize(ref asd, 1000);
        //}
        public int ProductId { get; set; }
        public HttpPostedFileBase[] Files{ get; set; }
    }
}