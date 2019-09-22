using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.TestesUnitarios
{
    [TestFixture]
    public class FizzBuzzTestes
    {
        [Test]
        public void GetOutput_QuandoRecebeUmNumeroMultiploDe15_DeveRetornarFizzBuzz()
        {
            var numero = 15;

            string resultado = FizzBuzz.GetOutput(numero);

            Assert.That(resultado, Is.EqualTo("FizzBuzz").IgnoreCase);
        }

        [Test]
        public void GetOutput_QuandoRecebeUmNumeroMultiploDe3ENaoMultiploDe5_DeveRetornarFizz()
        {
            var numero = 3;

            string resultado = FizzBuzz.GetOutput(numero);

            Assert.That(resultado, Is.EqualTo("Fizz").IgnoreCase);
        }

        [Test]
        public void GetOutput_QuandoRecebeUmNumeroMultiploDe5ENaoMultiploDe3_DeveRetornarBuzz()
        {
            var numero = 5;

            string resultado = FizzBuzz.GetOutput(numero);

            Assert.That(resultado, Is.EqualTo("Buzz").IgnoreCase);
        }

        [Test]
        public void GetOutput_QuandoRecebeUmNumeroNaoMultiploDe3NemDe5_DeveRetornarOProprioNumero()
        {
            var numero = 2;

            string resultado = FizzBuzz.GetOutput(numero);

            Assert.That(resultado, Is.EqualTo("2"));
        }
    }
}