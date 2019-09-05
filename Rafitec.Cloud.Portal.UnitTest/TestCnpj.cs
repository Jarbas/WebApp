using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rafitec.Cloud.Utils.Fiscal;

namespace Rafitec.Cloud.Portal.UnitTest
{
    [TestClass]
    public class TestCnpj
    {
        [TestMethod]
        public void TestMethodCnpj()
        {
            
            string cnpjValidar = "00.763.251/0001-28";

            bool cnpjValido = true;

            Assert.AreEqual(cnpjValido, Cnpj.Valido(cnpjValidar));
        }

        [TestMethod]
        public void TestMethodCnpjMascara()
        {
            string cnpjValidar = "10519377000377";

            string cnpjValido = "10.519.377/0003-77";

            Assert.AreEqual(cnpjValido, Cnpj.Montar(cnpjValidar));

        }
    }
}
