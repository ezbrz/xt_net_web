using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_06
{
    class Program
    {
        static void Main(string[] args)
        {
            FontAdjustment MyFont = new FontAdjustment();
            int fontParam;
            do
            {
                
                Console.WriteLine($"Параметры надписи:{MyFont}");
                getEnum();
                GetValue(out fontParam);

                switch (fontParam)
                {
                    case 1:
                        MyFont ^= FontAdjustment.bold;
                        break;
                    case 2:
                        MyFont ^= FontAdjustment.italic;
                        break;
                    case 3:
                        MyFont ^= FontAdjustment.underline;
                        break;
                }
            } while (fontParam != 4);
        }

        [Flags]
        enum FontAdjustment : byte
        {
            none = 0,
            bold = 1,
            italic = 2,
            underline = 4
        }

        static void getEnum()
        {
            for (int i = 1; i < Enum.GetValues(typeof(FontAdjustment)).Length; i++)
            {
                Console.WriteLine($"{i,10}: {Enum.GetValues(typeof(FontAdjustment)).GetValue(i)}");
            }
        }
        static int GetValue(out int val)
        {
            do
            {
                int.TryParse(Console.ReadLine(), out val);
                if (val <= 0||val > 4) Console.WriteLine($"incorrect, try again. value must  be >= 0 and <=3");
            } while (val <= 0|| val > 4);
            return val;
        }



    }
}
