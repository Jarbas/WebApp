using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rafitec.Cloud.Utils.Fiscal;

namespace Rafitec.Cloud.Portal.UnitTest
{
    [TestClass]
    public class TestCpf
    {
        [TestMethod]
        public void TestMethodCpf()
        {
            string cpfValidar = "004.642.009-62";

            bool cpfValido = true;

            Assert.AreEqual(cpfValido, Cpf.Valido(cpfValidar));
        }

        [TestMethod]
        public void TestMethodCpfMascara()
        {


            string cpfValidar = "00464200962";

            string cpfValido = "004.642.009-62";

            Assert.AreEqual(cpfValido, Cpf.Montar(cpfValidar));

        }

    }
}
