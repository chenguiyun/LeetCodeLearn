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
            //char[] te = "aabbcc".ToArray();
            //int[] nums = { 3, 10, 5, 25, 2, 8 };
            //int re = FindMaximumXOR(nums);
            //int[] num1 = { 1,2,3,0,0,0 };
            //int[] num2 = { 2, 5, 6 };
            //Merge(num1, 3, num2, 3);
            //int[] num1 = { 43, 85, 49, 2, 83, 2, 39, 99, 15, 70, 39, 27, 71, 3, 88, 5, 19, 5, 68, 34, 7, 41, 84, 2, 13, 85, 12, 54, 7, 9, 13, 19, 92 };
            //int[] num2 = { 10, 8, 53, 63, 58, 83, 26, 10, 58, 3, 61, 56, 55, 38, 81, 29, 69, 55, 86, 23, 91, 44, 9, 98, 41, 48, 41, 16, 42, 72, 6, 4, 2, 81, 42, 84, 4, 13 };
            //var r = Intersect(num1, num2);
            //var r = Generate(1);
            int[][] a = new int[][] {new[] {1, 2}, new[] {3, 4}, new[] { 5, 6 } };
            var r = MatrixReshape(a, 2, 3);
            Console.WriteLine(r);
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

        public bool UniqueOccurrences(int[] arr)
        {
            var li = new List<int>();
            foreach (var a in arr)
            {
                li.Add(a);
            }
            var aaa = li.Distinct();
            var bbb = new List<int>();
            foreach (var a in aaa)
            {
                bbb.Add(li.Count(t => t.Equals(a)));
            }
            var ccc = bbb.Distinct();
            if (bbb.Count > 0 && bbb.Count() > ccc.Count())
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 合并两个有序数组
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = 0; i < m; i++)
            {
                nums1[i] = nums1[i];
            }
            for (int j = 0; j < n; j++)
            {
                if (m+n>nums1.Length)
                {
                    nums1.Append(nums2[j]);
                }
                else
                {
                    nums1[j + m] = nums2[j];
                }
                
            }
            Array.Sort(nums1);
        }
        /// <summary>
        /// 两个数组的交集 II
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            var li=new List<int>();
            var l=new List<int>();
            var r= new List<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    if (nums1[i]==nums2[j])
                    {
                        if (r.Contains(j))
                        {
                        }
                        else if (l.Contains(i))
                        {
                            
                        }
                        else
                        {
                            l.Add(i);
                            r.Add(j);
                            li.Add(nums1[i]);
                        }
                        

                    }
                }
            }
            int[] re=li.ToArray();
            return re;
        }
        /// <summary>
        /// 买卖股票的最佳时机
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfit(int[] prices)
        {
            var profit = -10000;
            var ld = new Dictionary<int, int>();
            var rd = new Dictionary<int, int>();
            for (int i = prices.Length - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (prices[i] > prices[j])
                    {
                        var current = prices[i] - prices[j];
                        if (current > profit)
                        {
                            profit = current;
                        }
                    }
                }
            }
            if (profit <= 0)
            {
                return 0;
            }
            else
            {
                return profit;
            }
        }
        /// <summary>
        /// 杨辉三角
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static IList<IList<int>> Generate(int numRows)
        {
            //遍历解法
            /*
           IList<IList<int>> li = new List<IList<int>>();
           for (int i = 0; i < numRows; i++)
           {
               IList<int> re = new List<int>();
               for (int j = 0; j <= i; j++)
               {
                   if (j > 0 && j < i)
                   {
                       var lp = li[i - 1][j - 1];
                       var rp = li[i - 1][j];
                       var n = lp + rp;
                       re.Add(n);
                   }
                   else
                   {
                       re.Add(1);
                   }
               }
               li.Add(re);
           }
           return li;
            */

            //动态规划
            int[][] dp = new int[numRows][];
            dp[0] = new int[] {1};
            if (numRows>1)
            {
                dp[1] = new int[] { 1, 1 };
            }
            IList<IList<int>> li = new List<IList<int>>();
            for (int i = 2; i < numRows; i++)
            {
                dp[i]=new int[i+1];
                for (int j = 0; j < dp[i].Length;j++)
                {
                    if (j==0 || j==dp[i].Length-1)
                    {
                        dp[i][j] = 1;
                    }
                    else
                    {
                        dp[i][j] = dp[i - 1][j - 1] + dp[i - 1][j];
                    }
                }
                //li[i][i] = li[i - 1][i] + li[i - 1][i+1];
            }
            foreach (var d in dp)
            {
                li.Add(d);
            }
            return li;
        }
        /// <summary>
        /// 重塑矩阵
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            var h = mat.Length;
            var w = mat[0].Length;
            if (r*c==h*w)
            {
                int[][]m=new int[r][];
                var li =new List<int>();
                foreach (var i in mat)
                {
                    foreach (var j in i)
                    {
                        li.Add(j);
                    }
                }

                for (int i = 0; i < r; i++)
                {
                    m[i]=new int[c];
                    for (int j = 0; j < c; j++)
                    {
                        var a=new int();
                        a = li.FirstOrDefault();
                        li.RemoveAt(0);
                        m[i][j] = a;
                    }
                }

                return m;
            }
            else
            {
                return mat;
            }
        }
    }
}
