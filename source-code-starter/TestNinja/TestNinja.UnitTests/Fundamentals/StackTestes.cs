using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.TestesUnitarios.Fundamentals
{
    [TestFixture]
    public class StackTestes
    {
        private Stack<string> stack;

        [SetUp]
        public void SetUp()
        {
            stack = new Stack<string>();
        }

        [Test]
        public void Count_QuandoAStackForInicializada_DeveSerZero()
        {
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Count_AoSerChamado_DeveFuncionar()
        {
            Assert.That(stack.Count, Is.EqualTo(0));
            stack.Push("abc");
            Assert.That(stack.Count, Is.EqualTo(1));
            stack.Peek();
            Assert.That(stack.Count, Is.EqualTo(1));
            stack.Pop();
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Push_QuandoPassadoObjetoNulo_DeveErguerArgumentNullException()
        {
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_QuandoPassadoObjetoNaoNulo_DeveEmpilharOObjeto()
        {
            var texto = "abc";

            Assert.That(stack.Count, Is.EqualTo(0));
            stack.Push(texto);
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_QuandoAPilhaEstiverVazia_DeveErguerInvalidOperationException()
        {
            Assert.That(stack.Count, Is.EqualTo(0));

            var lancouExcecaoAdequada = false;

            try
            {
                stack.Pop();
            }
            catch (InvalidOperationException)
            {
                lancouExcecaoAdequada = true;
            }

            Assert.That(lancouExcecaoAdequada);
        }

        [Test]
        public void Pop_QuandoAPilhaNaoEstiverVazia_DeveExibirOUltimoObjetoInseridoNaPilha()
        {
            var texto1 = "abc";
            var texto2 = "def";
            stack.Push(texto1);
            stack.Push(texto2);
            Assert.That(stack.Count, Is.EqualTo(2));

            var textoPop = stack.Pop();

            Assert.That(textoPop, Is.EqualTo(texto2));
        }

        [Test]
        public void Pop_QuandoAPilhaNaoEstiverVazia_DeveRemoverOUltimoObjetoInseridoNaPilha()
        {
            var texto1 = "abc";
            var texto2 = "def";
            stack.Push(texto1);
            stack.Push(texto2);
            Assert.That(stack.Count, Is.EqualTo(2));

            stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Peek_QuandoAPilhaEstiverVazia_DeveErguerInvalidOperationException()
        {
            Assert.That(stack.Count, Is.EqualTo(0));

            var lancouExcecaoAdequada = false;

            try
            {
                stack.Peek();
            }
            catch (InvalidOperationException)
            {
                lancouExcecaoAdequada = true;
            }

            Assert.That(lancouExcecaoAdequada);
        }

        [Test]
        public void Peek_QuandoAPilhaNaoEstiverVazia_DeveExibirOUltimoObjetoInseridoNaPilha()
        {
            var texto1 = "abc";
            var texto2 = "def";
            stack.Push(texto1);
            stack.Push(texto2);
            Assert.That(stack.Count, Is.EqualTo(2));

            var textoPeek = stack.Peek();

            Assert.That(textoPeek, Is.EqualTo(texto2));
        }

        [Test]
        public void Peek_QuandoAPilhaNaoEstiverVazia_NaoDeveRemoverNenhumObjeto()
        {
            var texto1 = "abc";
            var texto2 = "def";
            stack.Push(texto1);
            stack.Push(texto2);
            Assert.That(stack.Count, Is.EqualTo(2));

            stack.Peek();

            Assert.That(stack.Count, Is.EqualTo(2));
        }
    }
}
