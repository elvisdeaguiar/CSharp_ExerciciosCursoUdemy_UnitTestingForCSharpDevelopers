using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.TestesUnitarios.Fundamentals
{
    [TestFixture]
    public class DemeritPointsCalculatorTestes
    {
        private const int LIMITE_DE_VELOCIDADE = 65;
        private const int VELOCIDADE_MAXIMA = 300;

        private DemeritPointsCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            this.calculator = new DemeritPointsCalculator();
        }

        [Test]
        public void CalculateDemeritPoints_QuandoReceberVelocidadeNegativa_DeveErguerOutOfRangeException()
        {
            var velocidade = -1;

            var lancouExcecaoAdequada = false;

            try
            {
                calculator.CalculateDemeritPoints(velocidade);
            }
            catch (ArgumentOutOfRangeException)
            {
                lancouExcecaoAdequada = true;
            }

            Assert.That(lancouExcecaoAdequada);
        }

        [Test]
        public void CalculateDemeritPoints_QuandoReceberVelocidadeAcimaDaVelocidadeMaxima_DeveErguerOutOfRangeException()
        {
            var velocidade = VELOCIDADE_MAXIMA + 1;

            var lancouExcecaoAdequada = false;

            try
            {
                calculator.CalculateDemeritPoints(velocidade);
            }
            catch (ArgumentOutOfRangeException)
            {
                lancouExcecaoAdequada = true;
            }

            Assert.That(lancouExcecaoAdequada);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(69, 0)]
        [TestCase(70, 1)]
        [TestCase(71, 1)]
        [TestCase(74, 1)]
        [TestCase(75, 2)]
        [TestCase(76, 2)]
        [TestCase(79, 2)]
        [TestCase(80, 3)]
        [TestCase(81, 3)]
        public void CalculateDemeritPoints_QuandoChamada_DeveCalcularOsPontosAdequadamente(int velocidade, int pontosEsperados)
        {
            var pontos = calculator.CalculateDemeritPoints(velocidade);

            Assert.That(pontos, Is.EqualTo(pontosEsperados));
        }
    }
}
