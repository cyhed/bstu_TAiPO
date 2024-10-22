using lab1;
using System;

namespace lab2
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class TestColorMix
    {
        [Test]
        public void ColorMix_RBGMixing_Half_Test()
        {
            lab1.Color A = new lab1.Color(255, 0, 0);
            lab1.Color B = new lab1.Color(0, 255, 0);

            lab1.Color expectedResult = new lab1.Color(128, 128, 0);
            lab1.Color actualResult = ColorMix.RGBMixing(A, B);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }


        public static object[] RBGMixing_HalfProportion_Cases =
        {
            new object[] { new lab1.Color(255, 0, 0),   new lab1.Color(0, 255, 0),    0.5f, new lab1.Color(128, 128, 0) },
            new object[] { new lab1.Color(255, 0, 0),   new lab1.Color(0, 255, 0),    1f,   new lab1.Color(255, 0, 0) },
            new object[] { new lab1.Color(255, 0, 0),   new lab1.Color(0, 255, 0),    0f,   new lab1.Color(0, 255, 0) }
        };       

        [TestCaseSource(nameof(RBGMixing_HalfProportion_Cases))]
        public void ColorMix_RBGMixing_HalfProportion_Test(Color a, Color b, float proportion, Color expectedResult)
        {
            lab1.Color actualResult = ColorMix.RGBMixing(a, b, proportion);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
       

        [TestCase(2f)]
        [TestCase(-2f)]
        public void ColorMix_RBGMixing_OutOfRange_Test(float proportion)
        {
            lab1.Color A = new lab1.Color();
            lab1.Color B = new lab1.Color();

            Assert.Throws<ArgumentOutOfRangeException>(() => { ColorMix.RGBMixing(A, B, proportion); });
        }

        [Test]
        public void ColorMix_RBGAMixing_Alpha255and255_Test()
        {
            lab1.Color A = new lab1.Color(255, 0, 0, 255);
            lab1.Color B = new lab1.Color(0, 255, 0, 255);

            lab1.Color expectedResult = new lab1.Color(128, 128, 0, 255);
            lab1.Color actualResult = ColorMix.RGBAMixing(A, B);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }



        public static object[] RBGAMixing_Alpha_Cases =
        {
            new object[] { new lab1.Color(255, 0, 0, 255),  new lab1.Color(0, 255, 0, 0) ,  new lab1.Color(255, 0, 0, 255) },
            new object[] { new lab1.Color(255, 0, 0, 0),    new lab1.Color(0, 255, 0, 255), new lab1.Color(0, 255, 0, 255) },
            new object[] { new lab1.Color(255, 0, 0, 0),    new lab1.Color(0, 255, 0, 0),   new lab1.Color(0, 0, 0, 0) }
        };

        [TestCaseSource(nameof(RBGAMixing_Alpha_Cases))]
        public void ColorMix_RBGAMixing_Alpha(Color a, Color b, Color expectedResult)
        {
            lab1.Color actualResult = ColorMix.RGBAMixing(a, b);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}