using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace ConsoleLeetCode
{
    public class Stack
    {
        public static void run()
        {
            var self =new Stack();
            //var test1 = "{()}[]]]]]]]";
            //var test2 = "([)]";
            //var test3 = "[][][]{[()]}";
            //var r=self.IsValid(test2);
            var q=new MyQueue();
            q.Push(1);
            q.Push(2);
            q.Push(3);
            var pop1 = q.Pop();
            var pop2 = q.Pop();
            var pop3 = q.Pop();
            Console.WriteLine(q);
        }

        /// <summary>
        /// 有效的括号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            //智慧结晶
            /*
            var r1 = false;
            var r2 = false;
            var a = s.Length/2-1;
            var b = s.Length/2;
            if (s.Length%2!=0)
            {
                return false;
            }
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i]);
                if (i + 1 <= s.Length && (vaild(s[i], s[i + 1])))
                {
                    r1 = true;
                }
                else
                { 
                    r1 = false;
                    break;
                }
                i++;
            }
            while (a >= 0 && b <= s.Length)
            {
                if (!vaild(s[a], s[b]))
                {
                    r2 = false;
                    break;
                }
                else
                {
                    r2 = true;
                }
                a--;
                b++;
            }
            if (r1 || r2)
            {
                return true;
            }
            else
            {
                return false;
            }*/
            //if (s.Length % 2 != 0)
            //{
            //    return false;
            //}
            var a = 0;
            var b = s.Length-1;
            var li = s.ToCharArray().ToList();
            /*
            while (a<= li.Count && b>=a)
            {
                Console.WriteLine(li[a]+"---"+li[b]);
                if(vaild(li[a], li[b]))
                {
                    li[a] = '0';
                    li.RemoveAt(b);
                    if (li.Count < 1)
                    {
                        return true;
                    }
                    a++;
                    b--;
                    //var s1 = s.Split(s[b]);
                    //s1[0] = s1[0] + s[b];
                    //if (s1[0]==s)
                    //{
                    //    if (s1[0].Length!=0 && s.Length % 2 == 0)
                    //    {
                    //        var sa = s.Remove(a, 1);
                    //        var sb = sa.Remove(b - 1, 1);
                    //        if (sb.Length<1)
                    //        {
                    //            return true;
                    //        }
                    //        else
                    //        {
                    //            return IsValid(sb);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        return false;
                    //    }
                    //}
                    //else
                    //{
                    //    if (s1[0].Length!=0)
                    //    {
                    //        return IsValid(s1[0]);
                    //    }

                    //    if (s1[1].Length != 0)
                    //    {
                    //        return IsValid(s1[1]);
                    //    }
                    //}
                }
                else
                {
                    b--;

                }
                if (a+b== li.Count)
                {
                    //break;
                }
                
            }
            */
            /*
            for (int i = 0; i < li.Count; i++)
            {
                var r = ""+li[i]+"---";
                for (int j = li.Count-1; j >0; j--)
                {
                    r = r + li[j];
                    if (vaild(li[i],li[j])&&li[i]!='x')
                    {
                        li[i] = 'x';
                        li[j] = 'x';
                        break;
                    }
                }
                Console.WriteLine(r);
            }

            if (li.Count(t=>!t.Equals('x'))>1)
            {
                return false;
            }
            */

            //st.Push('x');
            //foreach (var ss in s)
            //{
            //    st.Push(ss);
            //    var l = st.Peek();
            //    var r = ss;

            //}
            /*
            foreach (var t in s)
            {
                foreach (var ss in s)
                {
                    if (vaild(t,ss))
                    {
                        Console.WriteLine(t+"--"+ss);
                        st.Push(t);
                        st.Push(ss);
                        break;
                    }

                }
            }
            */
            //foreach (var ss in s)
            //{
            //    if (vaild(ss,st.Peek()))
            //    {
            //        Console.WriteLine(ss + "--" + st.Peek());
            //    }
            //    else
            //    {
            //        st.Pop();
            //    }
            //}
            /*
            var st = new Stack<char[]>();
            var i = 0;
            var j = i + 1;
            while (i<s.Length&&j<s.Length)
            {
                if (vaild(s[i],s[j]))
                {
                    var f = new []{ s[i],s[j] };
                    st.Push(f);
                    Console.WriteLine(s[i] + "--" + s[j]);
                    i++;
                    j = i + 1;
                }
                else
                {
                    if ((s[i]=='{'||s[i]=='['|| s[i]=='(')&&(s[j] == '{' || s[j] == '[' || s[j] == '('))
                    {
                        var f = new[] { s[i], s[j] };
                        st.Push(f);
                    }

                    if (j==s.Length-1)
                    {
                        i++;
                        j = i + 1;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            if (st.Count!=s.Length)
            {
                return false;
            }
            return true;
            */

            var len = s.Length;
            // 字符串长度为单数，直接返回`false`
            if (len % 2 == 1)
                return false;
            // 初始化栈
            var stack = new Stack<char>();
            for (int i = 0; i < len; i++)
            {
                // 遍历字符串中字符，当字符为左括号时，进栈对应右括号
                if (s[i] == '(')
                    stack.Push(')');
                else if (s[i] == '[')
                    stack.Push(']');
                else if (s[i] == '{')
                    stack.Push('}');
                // 如果字符是右括号时
                else
                    // 当栈为空或出栈字符不等于当前字符返回false
                if (stack.Count == 0 || stack.Pop() != s[i])
                    return false;
            }
            // 如果栈不为空，例如“((()”，返回false
            if (stack.Count > 0)
                return false;
            // 上面的校验都满足，则返回true
            else
                return true;
        }

        public bool vaild(char c1, char c2)
        {
            var r = false;
            switch (c1,c2)
            {
                case ('(',')'):
                    return true;
                case ('[', ']'):
                    return true;
                case ('{', '}'):
                    return true;
            }
            return false;
        }
    }
    /// <summary>
    /// 栈实现队列
    /// </summary>
    public class MyQueue
    {
        private Stack<int> i;
        private Stack<int> o;
        public MyQueue()
        {
            i=new Stack<int>();
            o=new Stack<int>();
        }

        public void Push(int x)
        {
            i.Push(x);
            o = reverse(i, o);
        }

        private Stack<int> reverse(Stack<int>i,Stack<int>o)
        {
            var oo=new Stack<int>();
            foreach (var ii in i)
            {
                oo.Push(ii);
            }
            return oo;
        }

        public int Pop()
        {
            var r = o.Pop();
            i=reverse(o, i);
            return r;
        }

        public int Peek()
        {
            return o.Peek();
        }

        public bool Empty()
        {
            if (i==null || i.Count==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
