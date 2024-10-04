using System.Drawing;

namespace lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            lab1.Color A = new lab1.Color(255, 0, 0);
            lab1.Color B = new lab1.Color(0, 255, 0);

            lab1.Color expectedResult = new lab1.Color(128, 128, 0);

            lab1.Color actualResult = ColorMix.RGBMixing(A, B);
            Console.WriteLine(actualResult.ToString() +" "+ expectedResult.ToString());
        }      

    }
    
}
