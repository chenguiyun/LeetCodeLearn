using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleLeetCode
{
    class Program
    {
        static void Main(string[] args)
        {

            //var re = Reverse(321);
            char[] te = "aabbcc".ToArray();
            int[] nums = { 3, 10, 5, 25, 2, 8 };
            int re = FindMaximumXOR(nums);
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

        public static int Compress(char[] chars)
        {
            var li = new List<string>();
            foreach (var c in chars)
            {
                li.Add(c.ToString());
            }
            var oli = li.ToList<string>();
            var reli = li.Distinct().ToList<string>();
            var li1 = new List<string>();
            var li2 = new List<string>();
            if (reli.Count <= 1) {
                return 1;
            }
            foreach (var r in reli)
            {
                li1.Add(r);
                var o = oli.Count(f => f.Equals(r));
                if (o > 1 && o < 10)
                {
                    li2.Add(o.ToString());
                }
                else if (o >= 0 && o < 100)
                {
                    li2.Add(o.ToString().ToCharArray()[0].ToString());
                    li2.Add(o.ToString().ToCharArray()[1].ToString());
                }
                else if (o >= 100 && o < 1000)
                {
                    li2.Add(o.ToString().ToCharArray()[0].ToString());
                    li2.Add(o.ToString().ToCharArray()[1].ToString());
                    li2.Add(o.ToString().ToCharArray()[2].ToString());
                }
                else 
                {
                    li2.Add(o.ToString().ToCharArray()[0].ToString());
                    li2.Add(o.ToString().ToCharArray()[1].ToString());
                    li2.Add(o.ToString().ToCharArray()[2].ToString());
                    li2.Add(o.ToString().ToCharArray()[3].ToString());
                }
            }
            var re = li1.Count + li2.Count;
            var s = "";
            foreach (var l in li1)
            {
                s = s + l;
            }
            foreach (var l in li2)
            {
                s = s + l;
            }
            chars = s.ToCharArray();
            var rs = "[";
            for (int i = 0; i < chars.Length; i++)
            {
                var end = ",";
                if (i == chars.Length - 1)
                {
                    end = "";
                }
                rs = rs + '"' + chars[i] + '"' + end;
            }
            rs = rs + "]";
            Console.Write(rs);
            return chars.Length;
        }

        public static int FindMaximumXOR(int[] nums)
        {
            var li = new List<int>();
            int i = 0;
            int j = 0;
            var re = new int[nums.Length * nums.Length];
            while (i < nums.Length && j < nums.Length)
            {
                var r = nums[i] ^ nums[j];
                if (i == j)
                {
                    if (i == 0 || i == nums.Length - 1)
                    {
                        re[(i) * (j)] = r;
                    }

                }
                else
                {
                    re[(i + 1) * (j + 1)] = r;
                }
                if (i == nums.Length - 1)
                {
                    i = 0;
                    j++;
                }
                else {
                    i++;
                }
            }
            return re.Max();
        }
    }
}
