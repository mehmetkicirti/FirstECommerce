using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SomethingHere.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int a = 10;
            int b = 1;
            int c = a / b;
            
        }
        [TestMethod]
        public void SumTest()
        {
            Math m = new Math();
            int result=m.Sum(5, 5);
            Assert.AreEqual(99, result);
        }
    }
}
