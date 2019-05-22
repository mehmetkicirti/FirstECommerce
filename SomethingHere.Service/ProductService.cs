using SomethingHere.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingHere.Service
{
    public class ProductService :BaseService, IService<Product>
    {
        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product entity)
        {
            Db.Product.Add(entity);
            Db.SaveChanges();
        }

        public List<Product> SelectAll()
        {
            return Db.Product.ToList();
        }

        public Product SelectByID(int id)
        {
            return Db.Product.Where(p => p.ID == id).SingleOrDefault();
        }
        public List<Product> LatestProducts()
        {
            return Db.Product.OrderByDescending(p => p.CreatedDate).Take(6).ToList();
        }
        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
        public List<Product> SelectByBrandId(int id)
        {
            return Db.Product.Where(b => b.BrandID == id).ToList();
        }
    }
}
