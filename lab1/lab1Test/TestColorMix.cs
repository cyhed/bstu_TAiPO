using lab1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1Test
{
    [TestFixture]
    public class TestColorMix
    {
        [Test]
        public void ColorMix_RBGMixing_Half_Test()
        {
            lab1.Color A = new lab1.Color(255, 0 , 0);
            lab1.Color B = new lab1.Color( 0, 255, 0);

            lab1.Color expectedResult = new lab1.Color(128,128,0);
            lab1.Color actualResult = ColorMix.RGBMixing(A, B);            

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ColorMix_RBGMixing_HalfProportion_Test()
        {
            lab1.Color A = new lab1.Color(255, 0, 0);
            lab1.Color B = new lab1.Color(0, 255, 0);
            float proportion = 0.5f;

            lab1.Color expectedResult = new lab1.Color(128, 128, 0);
            lab1.Color actualResult = ColorMix.RGBMixing(A, B, proportion);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ColorMix_RBGMixing_1Proportion_Test()
        {
            lab1.Color A = new lab1.Color(255, 0, 0);
            lab1.Color B = new lab1.Color(0, 255, 0);
            float proportion =1f;

            lab1.Color expectedResult = new lab1.Color(255, 0, 0);
            lab1.Color actualResult = ColorMix.RGBMixing(A, B, proportion);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ColorMix_RBGMixing_0Proportion_Test()
        {
            lab1.Color A = new lab1.Color(255, 0, 0);
            lab1.Color B = new lab1.Color(0, 255, 0);
            float proportion = 0f;

            lab1.Color expectedResult = new lab1.Color(0, 255, 0);
            lab1.Color actualResult = ColorMix.RGBMixing(A, B, proportion);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ColorMix_RBGMixing_OutOfRange_Test()
        {
            lab1.Color A = new lab1.Color();
            lab1.Color B = new lab1.Color();
            float proportion1 = 2f;
            float proportion2 = -2f;   

            Assert.Throws<ArgumentOutOfRangeException>(() => { ColorMix.RGBMixing(A, B, proportion1); } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { ColorMix.RGBMixing(A, B, proportion2); });  
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

        [Test]
        public void ColorMix_RBGAMixing_Alpha255and0_Test()
        {
            lab1.Color A = new lab1.Color(255, 0, 0, 255);
            lab1.Color B = new lab1.Color(0, 255, 0, 0);

            lab1.Color expectedResult = new lab1.Color(255, 0, 0, 255);
            lab1.Color actualResult = ColorMix.RGBAMixing(A, B);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        [Test]
        public void ColorMix_RBGAMixing_Alpha0and255_Test()
        {
            lab1.Color A = new lab1.Color(255, 0, 0, 0);
            lab1.Color B = new lab1.Color(0, 255, 0, 255);

            lab1.Color expectedResult = new lab1.Color(0, 255, 0, 255);
            lab1.Color actualResult = ColorMix.RGBAMixing(A, B);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        [Test]
        public void ColorMix_RBGAMixing_Alpha0and0_Test()
        {
            lab1.Color A = new lab1.Color(255, 0, 0, 0);
            lab1.Color B = new lab1.Color(0, 255, 0, 0);

            lab1.Color expectedResult = new lab1.Color(0, 0, 0, 0);
            lab1.Color actualResult = ColorMix.RGBAMixing(A, B);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
