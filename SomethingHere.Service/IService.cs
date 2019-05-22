using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingHere.Service
{
    public interface IService<T>
    {
            void Insert(T entity);
            void Delete(T entity);
        void Update(T entity);
        List<T> SelectAll();
        T SelectByID(int id);
            
    }
}
