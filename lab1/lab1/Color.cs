using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace lab1
{
    public class Color : IEquatable<Color>
    {
        byte alpha ;        
        byte red ;
        byte green ;
        byte blue;

        public Color()
        {
            red = 0; 
            green = 0; 
            blue = 0;
            alpha = 255;
        }
        public Color(byte red, byte green, byte blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            alpha = 255;
        }
        public Color(byte red, byte green, byte blue, byte alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = (byte)(alpha > 255 ? 255 : (alpha < 0 ? 0 : alpha));
        }
        public Color(byte red, byte green, byte blue, float alpha)
        {
            if (alpha < 0 || alpha > 1)
                throw new ArgumentOutOfRangeException(nameof(alpha));
            this.red = red;
            this.green = green;
            this.blue = blue;
            
            this.alpha = (byte)float.Round(alpha * 255);
        }
        public byte Red     { get { return this.red;    } set { this.red = value; } }
        public byte Green   { get { return this.green;  } set { this.green = value; } }
        public byte Blue   { get { return this.blue;   } set { this.blue = value; } }
        public byte Alpha   { get { return this.alpha; } set { this.alpha = value; } }

        public bool Equals(Color? other)
        {
            if(other.Red == this.Red 
                && other.Green == this.Green 
                && other.Blue == this.Blue 
                && other.Alpha == this.Alpha)
                return true;
            return false;
        }

        public override string ToString()
        {
            string rgb = "#" + red.ToString("X2") + green.ToString("X2") + blue.ToString("X2");
            if (alpha == 255)
                return rgb;
            else return rgb + alpha.ToString("X2");
        }
       
    }
}
