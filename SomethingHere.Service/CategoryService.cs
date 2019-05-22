using SomethingHere.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingHere.Service
{
    public class CategoryService :BaseService, IService<Category>
    {
        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> SelectAll()
        {
            return Db.Category.ToList();
        }

        public Category SelectByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
