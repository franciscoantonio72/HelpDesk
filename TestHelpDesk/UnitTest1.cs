using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHelpDesk
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TimeSpan tsInstance1 = new TimeSpan(1); //HH:mm:ss 
            TimeSpan tsInstance2 = new TimeSpan(7, 36, 10); //dd-HH:mm:ss 
            TimeSpan tsInstance3 = new TimeSpan(8, 2, 50, 10); //dd-HH:mm:ss.mmm (Milissegundos) 
            TimeSpan tsInstance4 = new TimeSpan(4, 7, 36, 10, 100);

            DateTime fim = DateTime.Now;
            string data = "14/11/2014 10:00:00";
            DateTime inicio = Convert.ToDateTime(data);
            TimeSpan diferenca = fim.Subtract(inicio);
            Assert.AreEqual(1, diferenca.Days);
            Assert.AreEqual(1, diferenca.Hours);
            Assert.AreEqual(50, diferenca.Minutes);
        }
    }
}
