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
            TimeSpan diferenca = Convert.ToDateTime("04/11/2014 08:00:00") - Convert.ToDateTime("03/11/2014 07:00:00");
            double diferencaDias = diferenca.TotalDays;
            double diferencaHoras = diferenca.TotalHours / 24;
            double diferencaMinutos = diferenca.TotalMinutes;
            double diferencaSegundos = diferenca.TotalSeconds;

            Assert.AreEqual(1, diferencaDias);
        }
    }
}
