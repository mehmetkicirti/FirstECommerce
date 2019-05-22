using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomethingHere.Web.UI.Models
{
    public class LoginCheckDTO
    {
        //SEALad class tan miras alınmaz 
        //16 kb dan fazla ise struct olur sealed miras almaz struct 
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}