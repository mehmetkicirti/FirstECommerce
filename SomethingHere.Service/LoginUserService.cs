using SomethingHere.DataAccess;
using SomethingHere.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingHere.Service
{
    public class LoginUserService : BaseService, IService<LoginUser>
    {
        public void Delete(LoginUser entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(LoginUser entity)
        {
            throw new NotImplementedException();
        }

        public List<LoginUser> SelectAll()
        {
            throw new NotImplementedException();
        }

        public LoginUser SelectByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(LoginUser entity)
        {
            throw new NotImplementedException();
        }
        public LoginUser CheckLogin(string username,string password)
        {
            password = CryptoManager.Encrypt(password);
           return Db.LoginUser.Where(p => p.Username == username && p.Password == password).SingleOrDefault();
        }
    }
}
