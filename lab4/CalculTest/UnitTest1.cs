using lab4;
using NUnit.Framework;
using System.Xml.Serialization;

namespace CalculTest
{

    [TestFixture]
    public class Tests 
    {
        
        CalculAPI calUI;
        
        public static lab4.TestCase[]? TestCasesSource;
        
        
        static Tests()
        {
           
            XmlSerializer formatter = new XmlSerializer(typeof(lab4.TestCase[]));

            // восстановление массива из файла
            using (FileStream fs = new FileStream("testCases.xml", FileMode.OpenOrCreate))
            {
                lab4.TestCase[]? newtestCases = formatter.Deserialize(fs) as lab4.TestCase[];

                if (newtestCases != null)
                {
                    TestCasesSource = newtestCases;
                }
            }
            
            

        }
        [OneTimeSetUp] public void OneTimeSetUp() { calUI = CalculAPI.getInstance(); }
       
       
        [Test, TestCaseSource(nameof(TestCasesSource))]
        public void Test(lab4.TestCase testCase)
        {
            string button = "";
            foreach (var data in testCase.TestData)
            {
                switch (data)
                {
                    case '(':
                        button = CalculAPI.SymbolsButtonRU.OpeningParenthesis;
                        break;
                    case ')':
                        button = CalculAPI.SymbolsButtonRU.ClosingParenthesis;
                        break;

                    case '0':
                        button = CalculAPI.NumbersButtonRU.Zero;
                        break;
                    case '1':
                        button = CalculAPI.NumbersButtonRU.One;
                        break;
                    case '2':
                        button = CalculAPI.NumbersButtonRU.Two;
                        break;
                    case '3':
                        button = CalculAPI.NumbersButtonRU.Three;
                        break;
                    case '4':
                        button = CalculAPI.NumbersButtonRU.Four;
                        break;
                    case '5':
                        button = CalculAPI.NumbersButtonRU.Five;
                        break;
                    case '6':
                        button = CalculAPI.NumbersButtonRU.Six;
                        break;
                    case '7':
                        button = CalculAPI.NumbersButtonRU.Seven;
                        break;
                    case '8':
                        button = CalculAPI.NumbersButtonRU.Eight;
                        break;
                    case '9':
                        button = CalculAPI.NumbersButtonRU.Nine;
                        break;

                    case '=':
                        button = CalculAPI.OperationsButtonRU.Equal;
                        break;
                    case '+':
                        button = CalculAPI.OperationsButtonRU.Plus;
                        break;
                    case '-':
                        button = CalculAPI.OperationsButtonRU.Minus;
                        break;
                    case '*':
                        button = CalculAPI.OperationsButtonRU.Multiplication;
                        break;
                    case '/':
                        button = CalculAPI.OperationsButtonRU.Division;
                        break;
                    default:
                        Assert.Fail();
                        break;
                }
                calUI.FindAndClickButton(button);

            }
            Assert.That(calUI.GetResult, Is.EqualTo("Отображать как "+testCase.ExpectedResult));
        }
    }
}
