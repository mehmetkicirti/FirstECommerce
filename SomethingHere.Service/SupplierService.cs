using SomethingHere.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingHere.Service
{
    public class SupplierService : BaseService ,IService<Supplier>
    {
        public void Delete(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public List<Supplier> SelectAll()
        {
            return Db.Supplier.ToList();
        }

        public Supplier SelectByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Supplier entity)
        {
            throw new NotImplementedException();
        }
    }
}
