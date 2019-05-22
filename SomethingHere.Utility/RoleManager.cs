using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingHere.Utility
{
    public class RoleManager
    {
        public static List<string> GetManagers()
        {//system config ekli olmalı degisiklikleri kaydedebilmek kullanıcıyı silmek istersek yayında iken
            List<string> managers = new List<string>();
            managers=ConfigurationManager.AppSettings["Manager"].Split(';').ToList();
            return managers;
        }
    }
}
