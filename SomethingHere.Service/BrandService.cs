using SomethingHere.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingHere.Service
{
    public class BrandService :BaseService, IService<Brand>
    {
        public void Delete(Brand entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Brand entity)
        {
            throw new NotImplementedException();
        }

        public List<Brand> SelectAll()
        {
            //SomethingsHereEntities entities = new SomethingsHereEntities();
            //List<Brand> brands = entities.Brands.ToList();
            return Db.Brand.ToList();
        }

        public Brand SelectByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand entity)
        {
            throw new NotImplementedException();
        }
    }
}
