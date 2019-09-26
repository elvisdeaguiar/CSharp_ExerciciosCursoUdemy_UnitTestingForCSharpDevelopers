using System;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.TestesUnitarios.Mocking 
{
    [TestFixture]
    public class InstallerHelperTestes 
    {
        const string PATH_ARQUIVO_FICTICIO = @"C:\pasta-ficticia\nome-arquivo-ficticio.txt";

        private InstallerHelper installerHelper;
        private Mock<IBaixadorDeArquivo> baixadorDeArquivoMock;

        [SetUp]
        public void SetUp()
        {
            baixadorDeArquivoMock = new Mock<IBaixadorDeArquivo>();
            installerHelper = new InstallerHelper(PATH_ARQUIVO_FICTICIO, baixadorDeArquivoMock.Object);
        }

        [Test]
        public void DownloadInstaller_QuandoCustomerNameForNull_DeveLancarArgumentNullException() 
        {
            var lancouExcecaoAdequada = false;
            string customerName = null;
            string installerName = "installer1";

            try
            {
                installerHelper.DownloadInstaller(customerName, installerName);
            }
            catch (ArgumentNullException)
            {
                lancouExcecaoAdequada = true;
            }

            Assert.That(lancouExcecaoAdequada);
        }

        [Test]
        public void DownloadInstaller_QuandoInstallerNameForNull_DeveLancarArgumentNullException() 
        {
            var lancouExcecaoAdequada = false;
            string customerName = "customer1";
            string installerName = null;

            try
            {
                installerHelper.DownloadInstaller(customerName, installerName);
            }
            catch (ArgumentNullException)
            {
                lancouExcecaoAdequada = true;
            }

            Assert.That(lancouExcecaoAdequada);
        }

        [Test]
        public void DownloadInstaller_QuandoReceberParametrosValidos_DeveChamarBaixadorDeArquivoComParametrosCorretos() 
        {
            string customerName = "customer1";
            string installerName = "installer1";

            installerHelper.DownloadInstaller(customerName, installerName);

            baixadorDeArquivoMock.Verify(ba => ba.BaixarArquivo("http://example.com/customer1/installer1", PATH_ARQUIVO_FICTICIO));
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(false, false)]
        public void DownloadInstaller_QuandoForChamadoComParametrosValidos_DeveRetornarOMesmoResultadoDeBaixarArquivo(bool resultadoRetornadoPorBaixarArquivo, bool resultadoEsperadoDeDownloadInstaller) 
        {
            string customerName = "customer1";
            string installerName = "installer1";
            baixadorDeArquivoMock.Setup(ba => ba.BaixarArquivo(It.IsAny<string>(), It.IsAny<string>())).Returns(resultadoRetornadoPorBaixarArquivo);

            bool resultadoDownloadInstaller = installerHelper.DownloadInstaller(customerName, installerName);

            Assert.That(resultadoDownloadInstaller, Is.EqualTo(resultadoEsperadoDeDownloadInstaller));
        }
    }
}