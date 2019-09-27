using System;

namespace ConsoleLeetCode
{
    class Program
    {
        static void Main(string[] args)
        {

            var re = Reverse(321);
            Console.WriteLine(re);
            Console.ReadKey();

        }
        public static int Reverse(int x)
        {
            var re = "";
            var s = "";
            try
            {
                if (x > 0)
                {
                    var c = x.ToString().ToCharArray();
                    for (int i = c.Length - 1; i >= 0; i--)
                    {
                        re = re + c[i].ToString();
                    }
                    return Convert.ToInt32(re);
                }
                else if (x == 0)
                {
                    return 0;
                }
                else
                {
                    var c = x.ToString().ToCharArray();
                    for (int i = c.Length - 1; i >= 1; i--)
                    {
                        re = re + c[i].ToString();
                    }
                    return (0 - Convert.ToInt32(re));
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
