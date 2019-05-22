using SomethingHere.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingHere.Service
{
    public class BaseService
    {
        //Bir nesnenin cok kullanılan mesela entities gibi bunu tekillestirilmesine Singleton Pattern
        public BaseService()
        {
            if (_db == null)
            {
                _db = new SomethingsHereEntities();
            }
        }
        //field => prop olmayan get-set olmayandı
        private SomethingsHereEntities _db;
        //bulundugu katmanın dısına cıkamaz yani malzeme ve mutfakta pisirdik sunum kısmında ne isi var bunun
        internal SomethingsHereEntities Db {
            get {

                return _db;
                }

        }

    }
}
