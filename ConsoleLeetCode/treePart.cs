using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Linq.Expressions;
using System.Text;

namespace ConsoleLeetCode
{
    public class treePart
    {
        public static void run()
        {
            TreeNode tn=new TreeNode(1);
            tn.left = new TreeNode(2);
            tn.right= new TreeNode(3);
            tn.left.left = new TreeNode(4);
            tn.left.right = new TreeNode(5);
            tn.right.left = new TreeNode(6);
            tn.right.right = new TreeNode(7);
            tn.right.left = null;

            TreeNode fn =new TreeNode(1);
            fn.left =new TreeNode(2);
            fn.left.right = new TreeNode(3);
            fn.right = new TreeNode(2);
            fn.right.right = new TreeNode(3);
            //tn.left.right = new TreeNode(2);
            //tn.left.right =new TreeNode(4);
            var self=new treePart();
            //self.LevelOrder(tn);
            //self.MaxDepth(tn);
            self.IsSymmetric(fn);
        }
        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal(TreeNode root)
        {
            var li=new List<int>();
            Ptreefor(root,li);
            return iterationPreorderTraversal(root);
        }
        /// <summary>
        /// 二叉树的中序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal(TreeNode root)
        {
            var li = new List<int>();
            Itreefor(root, li);
            return li;
        }
        /// <summary>
        /// 二叉树的后序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal(TreeNode root)
        {
            var li = new List<int>();
            Posttreefor(root, li);
            return li;
        }

        /// <summary>
        /// 迭代法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> iterationPreorderTraversal(TreeNode root)
        {
            /*
            var li = new List<int>();
            var r= new TreeNode();
            if (root!=null && root.right!=null)
            {
                r = root.right;
            }
            var pt=new TreeNode(-1);
            pt.left = root;
            while (root!=null && pt!=null)
            {
                li.Add(root.val);
                /*
                if (root.left==null && root.right!=null)
                {
                    root.left = root.right;
                }
                else if (root.left!=null && root.right != null)
                {
                    if (root.left.left==null && root.left.right!=null)
                    {
                        root.left.left = root.left.right;
                        root.left.right = root.right;
                    }
                    else
                    {
                        if (root.left.right==null)
                        {
                            root.left.right = root.right;
                        }
                    }
                }
                else if (root.left==null && root.right==null && r!=null)
                {
                    root.left = r;
                    r = null;
                }
                pt = root.left;
                root = root.left;
                return li;
                */
                var res = new List<int>();
                if (root == null)
                    return res;
                var stack = new Stack<TreeNode>();
                stack.Push(root);
                while (stack.Count > 0)
                {
                    var temp = stack.Pop();
                    res.Add(temp.val);
                    if (temp.right != null)
                        stack.Push(temp.right);
                    if (temp.left != null)
                        stack.Push(temp.left);
                }
                return res;


            
        }

        /// <summary>
        /// 二叉树的层序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> res= new List<IList<int>>();
            if (root == null)
            {
                return res;
            }
            var q=new Queue<TreeNode>();
            q.Enqueue(root);
            int a = 0;
            var d = 1;
            while (a<d)
            {
                var li = new List<int>();
                var b = 0;
                 while (b<q.Count)
                {
                    var r = q.Peek();
                    li.Add(r.val);
                    if (r.left != null)
                    {
                        q.Enqueue(r.left);
                        b++;
                    }
                    if (r.right != null)
                    {
                        q.Enqueue(r.right);
                        b++;
                    }
                    if (r.left == null || r.right == null)
                    {
                    }
                    else
                    {
                    }
                    q.Dequeue();
                    
                }
                a++;
                if (li.Count!=0)
                {
                    d++;
                    res.Add(li);
                }
            }

            /*
             while (queue.Count > 0) {
            IList<int> levelValues = new List<int>();
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                TreeNode node = queue.Dequeue();
                levelValues.Add(node.val);
                if (node.left != null) {
                    queue.Enqueue(node.left);
                }
                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
            }
            res.Add(levelValues);
            }
             */
            return res;
        }

        /// <summary>
        /// 二叉树的最大深度
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            if (root==null)
            {
                return 0;
            }
            var q=new Queue<TreeNode>();
            q.Enqueue(root);
            var depth = 0;
            while (q.Count>0)
            {
                var size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    var r = q.Dequeue();
                    var a = r.val;
                    if (r.left != null)
                    {
                        q.Enqueue(r.left);
                    }
                    if (r.right != null)
                    {
                        q.Enqueue(r.right);
                    }
                }
                depth++;
            }
            return depth;
        }

        /// <summary>
        /// 对称二叉树
        /// 检查二叉树是否对称
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            if (root==null)
            {
                return false;
            }
            var lq=new Queue<TreeNode>();
            lq.Enqueue(root.left);
            var rq=new Queue<TreeNode>();
            rq.Enqueue(root.right);
            var li=new List<int>();
            var ri=new List<int>();
            if (lq.Count!=rq.Count)
            {
                return false;
            }
            while (lq.Count>0)
            {
                var lsize = lq.Count;
                for (int i = 0; i < lsize; i++)
                {
                    var l = lq.Dequeue();
                    if (l!=null)
                    {
                        li.Add(l.val);
                        lq.Enqueue(l.left);
                        lq.Enqueue(l.right);
                    }
                    else
                    {
                        li.Add(-10000);
                    }
                    
                    //if (l.left!=null)
                    //{
                        
                    //}
                    //if (l.right!=null)
                    //{
                        
                    //}
                }
                
            }
            while (rq.Count>0)
            {
                var rsize = rq.Count;
                for (int j = 0; j < rsize; j++)
                {
                    var r = rq.Dequeue();
                    if (r!=null)
                    {
                        ri.Add(r.val);
                        rq.Enqueue(r.right);
                        rq.Enqueue(r.left);
                    }
                    else
                    {
                        ri.Add(-10000);
                    }

                    //if (r.right != null)
                    //{
                        
                    //}
                    //if (r.left != null)
                    //{
                        
                    //}
                }
            }

            if (li.Count!=ri.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < li.Count; i++)
                {
                    var l = li[i];
                    var r = ri[i];
                    if (l!=r)
                    {
                        return false;
                    }
                }
            }
            return true;

            /*双队列同时遍历
             *while(queue.Count()!=0)
            {
            left = queue.Dequeue();
            right = queue.Dequeue();
            if(left==null && right==null)
            {
                continue;
            }
            if((left==null || right==null) || (left.val != right.val))
            {
                return false;
            }

            queue.Enqueue(left.left);
            queue.Enqueue(right.right);

            queue.Enqueue(left.right);
            queue.Enqueue(right.left);
            } 
             *
             */
        }

        public void Ptreefor(TreeNode root, IList<int> li)
        {
            if (root!=null)
            {
                li.Add(root.val);
                if (root.left!=null)
                {
                    Ptreefor(root.left, li);
                }
                if (root.right!=null)
                {
                    Ptreefor(root.right,li);
                }
            }
        }
        public void Itreefor(TreeNode root, IList<int> li)
        {
            if (root != null)
            {
                if (root.left != null)
                {
                    Itreefor(root.left, li);
                }
                li.Add(root.val);
                if (root.right != null)
                {
                    Itreefor(root.right, li);
                }
            }
        }
        public void Posttreefor(TreeNode root, IList<int> li)
        {
            if (root != null)
            {
                if (root.left != null)
                {
                    Posttreefor(root.left, li);
                }
                if (root.right != null)
                {
                    Posttreefor(root.right, li);
                }
                li.Add(root.val);
            }
        }

    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
