
using NUnit.Framework.Legacy;

namespace lab1Test
{
    [TestFixture]
    public class TEST 
    {

        private lab1.Calculatoin _calcul;

        [SetUp]
        public void SetUp()
        {
            _calcul = new lab1.Calculatoin();
        }


        [Test]
        public void Multiplication_Result_Success() {
            int A = 5;
            int B = 2;

            int expectedResult = 10;

            int actualResult = _calcul.Multiplication(A, B);

            
            ClassicAssert.IsTrue(actualResult >= 0);
            ClassicAssert.IsInstanceOf<int>(actualResult);

            Assert.That(actualResult, Is.EqualTo(expectedResult));

        }
    }
}
