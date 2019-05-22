using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomethingHere.Web.UI;

namespace SomethingHere.Test
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void AddTest()
        {
            CartManager manager = new CartManager();
            manager.Add(12);
            manager.Add(16);
            manager.Add(15);
            manager.Add(12);
            manager.Add(15);
        }
    }
}
