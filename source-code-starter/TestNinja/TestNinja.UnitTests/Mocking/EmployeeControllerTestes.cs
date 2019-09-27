using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.TestesUnitarios.Mocking
{
    [TestFixture]
    public class EmployeeControllerTestes
    {
        private Mock<IRepositorioEmployee> _employeeRepositorio;
        private EmployeeController _employController;

        [SetUp]
        public void SetUp()
        {
            _employeeRepositorio = new Mock<IRepositorioEmployee>();
            _employController = new EmployeeController(_employeeRepositorio.Object);
        }

        [Test]
        public void DeleteEmployee_QuandoChamado_DeveChamarDeleteEmployeeDeRepositorioEmployeeComMesmoId()
        {
            _employController.DeleteEmployee(1);

            _employeeRepositorio.Verify(er => er.DeleteEmployee(1));
        }

        [Test]
        public void DeleteEmployee_QuandoChamado_DeveRetornarUmRedirectResult()
        {
            ActionResult resultado = _employController.DeleteEmployee(1);

            Assert.That(resultado, Is.TypeOf<RedirectResult>());
        }
    }
}
