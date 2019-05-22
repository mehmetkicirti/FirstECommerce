using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingHere.DataAccess
    //partial kullanırken quantity üründe anlık ekleme yaparken kullanılır bu class calısırken kordineli calıscak ve partial class varsa bunlar birbirini ezebilir demektir aynı namespace ile aynı isim ile kullanılır
{
    public partial class Product
    {
        public int Quantity { get; set; }
        public decimal TotalPrice {//geriye döndürmücek bundan dolayı kullanabliriz..
            get
            {
                return (decimal)(this.Quantity * this.Price);
            }
                
                }
    }
}
