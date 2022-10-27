using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace ConsoleLeetCode
{
    public static class linklist
    {
        public static void run()
        {
            //int[] a={3,2,0,-4};
            //var ln=new ListNode(3);
            //ln.next = new ListNode(2);
            //ln.next.next=new ListNode(0);
            //ln.next.next.next = new ListNode(-4);
            //ln.next.next.next.next = ln.next;
            //var lll=new LinkedList<ListNode>();
            //lll.AddFirst(ln);
            //var aaa=HasCycle(ln);
            //Console.WriteLine(aaa);
            var node5 = new ListNode(1, null);
            var node4 = new ListNode(1, node5);
            var node3=new ListNode(1, node4);
            var node2 = new ListNode(1, node3);
            var node1 = new ListNode(1, node2);

            var dnode3 = new ListNode(6, null);
            var dnode2 = new ListNode(5, dnode3);
            var dnode1 = new ListNode(2, dnode2);

            var r = MergeTwoLists(node1,dnode1);
            var rs = RemoveElements(node1, 1);
        }

        /// <summary>
        /// 环形链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool HasCycle(ListNode head)
        {
            var li = new List<ListNode>();
            //var l =new int[4];
            //var i = 0;
            //re(l,head,i);
            return vaild(li, head);
        }

        public static void re(int[] r,ListNode head,int i)
        {
            if (head!=null)
            {
                r.SetValue(head.val,i);
                i++;
                re(r,head.next,i);
            }
        }

        public static bool vaild(List<ListNode> l, ListNode head)
        {

            //var n = true;
            //get(n,li,head);
            //return n;
            if (head != null)
            {
                if (l.Contains(head))
                {
                    return true;
                }
                l.Add(head);
                if (head.next != null)
                {
                    return vaild(l, head.next);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public static ListNode insert(ListNode ln,ListNode next)
        {
            ln.next = next;
            return insert(next,next.next);
        }

        /// <summary>
        /// 合并两个有序链表
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var r=new ListNode(0,null);
            var li1 = new List<int>();
            var li2 = new List<int>();
            while (list1 != null)
            {
                li1.Add(list1.val);

                list1 = list1.next;
            }

            while (list2 != null)
            {
                li2.Add(list2.val);
                list2 = list2.next;

            }
            li1.AddRange(li2);
            li1.Sort();
            if (li1.Count<1)
            {
                return null;
            }
            r = new ListNode(li1[0]);
            var li=new List<ListNode>();
            li.Add(r);
            for (int i = 1; i < li1.Count; i++)
            {
                
                var node=new ListNode(li1[i]);
                r.next = node;
                r = r.next;
            }
            return li[0];
        }
        /// <summary>
        /// 移除链表元素
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static ListNode RemoveElements(ListNode head, int val)
        {
            var li=new List<ListNode>();
            var prehead = new ListNode(-1);
            prehead.next = head;
            var pre = prehead;
            li.Add(pre);
            while (head!=null && pre!=null)
            {
                //Console.WriteLine(head.val);
                if (head.val==val)
                {
                    if (pre.next==head)
                    {
                        var p = head.next;
                        pre.next = null;
                        head = null;
                        head = p;
                        pre.next = p;
                    }
                    else if (head.next==null)
                    {
                        head = null;
                    }
                    else
                    {
                        pre.next = head.next;
                    }

                }
                else
                {
                    pre = pre.next;
                    head = head.next;
                }


                }
            return li[0].next;
        }
    }
    
  public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x)
        {
            val = x;
            next = null;
        }
      public ListNode(int val = 0, ListNode next = null)
      {
          this.val = val;
          this.next = next;
      }
    }

}
