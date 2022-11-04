using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var nums = new []{ -2, 0, 0, 2, 2 };
            //s.MajorityElement(nums);
            s.ThreeSum(nums);
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
    }
}
