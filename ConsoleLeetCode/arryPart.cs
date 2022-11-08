using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleLeetCode
{
    /// <summary>
    /// 数组部分
    /// </summary>
    public class arryPart
    {
        public static void run()
        {
            var s=new arryPart();
            var nums = new []{ 4,5,6,3,2,1 };
            s.SortColors(nums);
            var a = 0;
            var hash=new MyHashMap();
           
            //s.GetRow(3);
            //s.GenerateMatrix(4);
            int[][] m1 = new int[][] { new[] { 1, 2,3 }, new[] { 4,5,6 }, new[] { 7,8,9 } };
            int[][] m2 = new int[][] { new[] { 1, 4, 7, 11, 15 }, new[] { 2, 5, 8, 12, 19 } 
                , new[] { 3, 6, 9, 16, 22 } , new[] { 10, 13, 14, 17, 24 },new[]{ 18, 21, 23, 26, 30 }   };
            int[][] m3 = new int[][] { new[] { 1,3,5}, /*new[] { 3 }, new[] { 5 }*/ };
            s.Rotate(m1);
            s.SearchMatrix(m3,3);
            int[][] t1 = new int[][] { new[] { 1, 5}, new[] { 2, 3}, new[] { 3, 6}, new[] { 1, 4 }};
            s.EraseOverlapIntervals(t1);
            //s.MajorityElement(nums);
            //s.ThreeSum(nums);
        }

        /// <summary>
        /// 只出现一次的数字
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            Array.Sort(nums);
            int s = 0;
            foreach (var n in nums)
            {
                s=s^n;
            }
            return s;
            for (int i = 0; i < nums.Length;i++)
            {
                var equalnum = 0;
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i]==nums[j])
                    {
                        nums[i] = -100000000;
                        nums[j] = -100000000;
                        break;
                    }
                }
            }
            return nums.FirstOrDefault(t=>!t.Equals(-100000000));
        }

        /// <summary>
        /// 多数元素
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
            //超过一半的连续众数必定在中间出现
            var num = nums.Length / 2;
            var nums2 = nums.Distinct().ToList();
            for (int i = 0; i < nums2.Count(); i++)
            {
                var sum = nums.Count(t=>t.Equals(nums2[i]));
                if (sum>num)
                {
                    return nums2[i];
                }
            }

            return 0;
        }

        /// <summary>
        /// 三数之和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var res=new List<IList<int>>();
            var target = 0;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                var find = target-nums[i];
                var j = i+1;
                var k = nums.Length -1;
                while (j<k)
                {
                    var sum = nums[j] + nums[k];
                    if (sum == find && i != j && i != k && j != k)
                    {
                        //var arr = new int[] { i, j, k };
                        var li = new List<int>();
                        var issame = false;
                        //判断是否有重复
                        foreach (var r in res)
                        {
                            if (r[0] == nums[i] && r[1] == nums[j] && r[2] == nums[k])
                            {
                                issame = true;
                                break;
                            }
                        }
                        if (!issame)
                        {
                            li.Add(nums[i]);
                            li.Add(nums[j]);
                            li.Add(nums[k]);
                            res.Add(li);
                        }
                        j++;

                    }
                    else if (sum<find)
                    {
                        j++;
                    }
                    else if (sum>find)
                    {
                        k--;
                    }
                }
                /*for (int j = i + 1; j < nums.Length; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[j] + nums[k] == find && i!=j &&i!=k&&j!=k)
                        {
                            //var arr = new int[] { i, j, k };
                            var li=new List<int>();
                            var issame = false;
                            foreach (var r in res)
                            {
                                if (r[0]== nums[i]&& r[1] == nums[j] && r[2] == nums[k] )
                                {
                                    issame = true;
                                    break;
                                }
                            }
                            if (!issame)
                            {
                                li.Add(nums[i]);
                                li.Add(nums[j]);
                                li.Add(nums[k]);
                                res.Add(li);
                            }

                        }
                    }
                        
                        
                }*/


            }
            return res;
        }

        /// <summary>
        /// 颜色分类，从小到大
        /// </summary>
        /// <param name="nums"></param>
        public void SortColors(int[] nums)
        {
            //荷兰国旗问题 统计 0 1 2 的个数 然后打印
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i]>nums[j])
                    {
                        var temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
            /*
            while (left >= right)
            {
                if (nums[right] < nums[left])
                {
                    right--;
                }
                else
                {
                    var temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;
                    left++;
                }
            }
            */
        }

        /// <summary>
        /// 合并区间
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int[][] Merge(int[][] intervals)
        {
            var li = intervals.ToList();
            var start = 0;
            var end = 1;
            var c=new int[0];
            var next=new int[0];
            for (int i = 0; i < li.Count; i++)
            {
                for (int j = i+1; j < li.Count; j++)
                {
                    if (li[i][0]>li[j][0])
                    {
                        var temp = li[i];
                        li[i] = li[j];
                        li[j] = temp;
                    }
                    c = li[i];
                    next = li[j];
                    var changed = false;
                    if (c[start]<=next[start] && c[end]<=next[end] && c[end]>=next[start])
                    {
                        c[end] = next[end];
                        li.Remove(next);
                        changed = true;
                    }
                    else if (c[start]<=next[start] && c[end]>=next[end])
                    {
                        li.Remove(next);
                        changed = true;
                    }
                    else if (next[start]<=c[start] && next[end]<=c[end] && next[end]>=c[start])
                    {
                        next[end] = c[end];
                        li.Remove(c);
                        changed = true;
                    }
                    else if (next[start]<=c[start] && next[end]>=c[end])
                    {
                        li.Remove(c);
                        changed = true;
                    }

                    if (changed)
                    {
                        i--;
                    }
                }
            }
            
            return li.ToArray();
        }



        /// <summary>
        /// 杨辉三角 II
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public IList<int> GetRow(int rowIndex)
        {
            var trangle=new List<List<int>>();
            var li=new List<int>();
            li.Add(1);
            trangle.Add(li);
            li = new List<int>();
            li.Add(1);
            li.Add(1);
            trangle.Add(li);
            if (rowIndex>2)
            {
                for (int i = 1; i < rowIndex; i++)
                {
                    li=new List<int>();
                    li.Add(1);
                    for (int j = 1; j < trangle[i].Count; j++)
                    {
                        li.Add(trangle[i][j-1]+trangle[i][j]);
                    }
                    li.Add(1);
                    trangle.Add(li);
                }
            }
            return trangle[rowIndex];
        }


        
        /// <summary>
        /// 螺旋矩阵 II
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[][] GenerateMatrix(int n)
        {
            int x = 0;
            int y = 0;
            MyEnum fx = MyEnum.right;
            int[][] arry= new int[n][];
            for (int i = 0; i < arry.Length; i++)
            {
                var a = new int[n];
                arry[i] = a;
            }
            
            var li=new List<martixlab>();
            
            for (int i = 1; i <=n*n; i++)
            {
                arry[x][y] = i;
                var a = new martixlab(x, y);
                li.Add(a);
                var next = new martixlab(1, 2);
                next = null;
                if (fx.Equals(MyEnum.right))
                {
                    next = single(li,x, y + 1);
                }
                else if (fx.Equals(MyEnum.down))
                {
                    next = single(li, x+1, y);
                }
                else if (fx.Equals(MyEnum.left))
                {
                    next = single(li, x, y-1);
                }
                else if (fx.Equals(MyEnum.up))
                {
                    next = single(li, x-1, y);
                }



                //左向右
                if (y < arry.Length - 1 && fx.Equals(MyEnum.right) && next == null)
                {
                    y = y + 1;
                }
                else if ((y == arry.Length - 1 ||y<next?.y) && fx.Equals(MyEnum.right))
                {
                    fx = MyEnum.down; 
                    x++;
                }
                //上向下
                else if(x < arry.Length - 1 && fx.Equals(MyEnum.down) && next == null)
                {
                    x++;
                }
                else if ((x == arry.Length - 1||x<next?.x) && fx.Equals(MyEnum.down))
                {
                    fx = MyEnum.left;
                    y--;
                }
                //右向左
                else if(y > 0 && fx.Equals(MyEnum.left) && next == null)
                {
                    y--;
                }
                else if ((y == 0 ||y>next?.y) && fx.Equals(MyEnum.left))
                {
                    fx = MyEnum.up;
                    x--;
                }
                //下向上
                else if(x > 0 && fx.Equals(MyEnum.up) && next==null)
                {
                    x--;
                }
                else if ((x == 0||x>next?.x) && fx.Equals(MyEnum.up))
                {
                    fx = MyEnum.right;
                    y++;
                }

                
            }

            return arry;
        }

        public martixlab single(List<martixlab> li,int x,int y)
        {
            foreach (var ll in li)
            {
                if (ll.x==x&&ll.y==y)
                {
                    return ll;
                }
            }
            return null;
        }

        public enum MyEnum
        {
            up=8,
            down=2,
            left=4,
            right=6

        }

        public class martixlab
        {
            public int x { get; set; }
            public int y { get; set; }

            public martixlab(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        //todo 待理解
        /// <summary>
        /// 旋转图像
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {
            var li=new List<int>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    
                }
            }
            var a=0;
        }
        /// <summary>
        /// 搜索二维矩阵 II
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            //行遍历
            for (int i = 0; i < matrix.Length; i++)
            {
                //判断目标值是否在该行内
                if (target>=matrix[i][0]&& target <= matrix[i][matrix[i].Length - 1])
                {
                    //行头或者行尾相等
                    if (target== matrix[i][0]||target== matrix[i][matrix[i].Length - 1])
                    {
                        return true;
                    }
                    //遍历该行其他元素
                    for (int j = 1; j < matrix[i].Length - 1; j++)
                    {
                        if (target == matrix[i][j])
                        {
                            return true;
                        }
                    }
                }
            }
            /*
            for (int i = 0; i < xlist.Count; i++)
            {
                if (target>=xlist[i] && target<=matrix[i][matrix[i].Length-1])
                {
                    if (target==xlist[i])
                    {
                        return true;
                    }
                    li.Add(i);
                }
            }*/
            return false;
        }

        /// <summary>
        /// 无重叠区间
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int EraseOverlapIntervals(int[][] intervals)
        {
            var start = 0;
            var end = 1;
            var num = 0;
            intervals = sortintervals(intervals);
            for (int i = 0; i < intervals.Length; i++)
            {
                for (int j = i+1; j < intervals.Length; j++)
                {
                    var cur = intervals[i];
                    var next = intervals[j];

                }
            }
            return num;
        }

        public int[][] sortintervals(int[][] intervals)
        {
            for (int i = 0; i < intervals.Length; i++)
            {
                for (int j = i+1; j < intervals.Length; j++)
                {
                    if (intervals[i][0]>intervals[j][0])
                    {
                        var t = intervals[i];
                        intervals[i] = intervals[j];
                        intervals[j] = t;
                    }
                    
                }

                //for (int j = i+1; j < intervals.Length; j++)
                //{
                //    if (intervals[i][1]>intervals[j][1])
                //    {
                //        var t = intervals[i];
                //        intervals[i] = intervals[j];
                //        intervals[j] = t;
                //    }
                //}
            }
            return intervals;
        }
    }

    /// <summary>
    /// 设计哈希映射

    /// </summary>
    public class MyHashMap
    {
        class MyHashObject
        {
            public int key { get; set;}
            public int value { get; set; }
        }
        private List<MyHashObject> li;
        public MyHashMap()
        {
            li=new List<MyHashObject>();
            //arry=new object[0];
        }

        public void Put(int key, int value)
        {
            var s = GetHashObject(key);
            if (s!=null)
            {
                s.value = value;
            }
            else
            {
                var a=new MyHashObject();
                a.key = key;
                a.value = value;
                li.Add(a);
            }
        }


        private MyHashObject GetHashObject(int key)
        {
            for (int i = 0; i < li.Count; i++)
            {
                if (li[i].key==key)
                {
                    return li[i];
                }
            }
            return null;
        }


        public int Get(int key)
        {
            var s = GetHashObject(key);
            if (s!=null)
            {
                return s.value;
            }
            else
            {
                return -1;
            }
        }

        public void Remove(int key)
        {
            var s = GetHashObject(key);
            if (s != null)
            {
                li.Remove(s);
            }
        }
    }
}
