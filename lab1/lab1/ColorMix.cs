using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public  static class ColorMix
    {
        
       public static Color RGBMixing(Color color1, Color color2)
       {            
            byte red =  (byte)float.Round((color1.Red  + color2.Red)   /2f);
            byte green =(byte)float.Round((color1.Green+ color2.Green) /2f);
            byte blue = (byte)float.Round((color1.Blue + color2.Blue)  /2f);
            return new Color(red, green, blue);
       }
        public static Color RGBMixing(Color color1, Color color2, float proportion) {
            if (!CheckCorrectnessPercentages(proportion)) {
                throw new ArgumentOutOfRangeException(nameof(proportion));
            }

            if (proportion == 0.5f)
                return RGBMixing(color1,color2);

            float q = 1 - proportion;

            byte red =  (byte)float.Round(color1.Red * proportion + color2.Red   * q);
            byte green =(byte)float.Round(color1.Green * proportion + color2.Green * q);
            byte blue = (byte)float.Round(color1.Blue  * proportion + color2.Blue  * q);

            return new Color(red, green, blue);
        }
        public static Color RGBAMixing(Color color1, Color color2)
        {
            if (color1.Alpha == 255 && color2.Alpha == 255)
                return RGBMixing(color1, color2);

            float alpha1 = (color1.Alpha / 255.0f);
            float alpha2 = (color2.Alpha / 255.0f);

            float alpha =(1 - (1 - alpha1) * (1 - alpha2));
            byte red =  (byte)float.Round((color1.Red   * alpha1 * (1 - alpha2) + color2.Red    * alpha2) / alpha);
            byte green =(byte)float.Round((color1.Green * alpha1 * (1 - alpha2) + color2.Green  * alpha2) / alpha);
            byte blue = (byte)float.Round((color1.Blue  * alpha1 * (1 - alpha2) + color2.Blue   * alpha2) / alpha);
            
            return new Color(red, green, blue, alpha);
        }
        
        private static bool CheckCorrectnessPercentages(float proportion)
        {
           return 0 <= proportion && proportion <= 1;
        }
    }
}
