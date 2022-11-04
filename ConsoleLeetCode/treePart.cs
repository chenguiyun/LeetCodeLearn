using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

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

            TreeNode fn =new TreeNode(5);
            fn.left =new TreeNode(4);
            fn.left.left = new TreeNode(11);
            fn.left.left.left = new TreeNode(7);
            fn.left.left.right = new TreeNode(2);
            fn.right = new TreeNode(8);
            fn.right.left =new TreeNode(13);
            fn.right.right = new TreeNode(4);
            fn.right.right.right = new TreeNode(1);

            TreeNode bn = new TreeNode(4);
            bn.left=new TreeNode(3);
            bn.left.left = new TreeNode(2);
            bn.left.left.left = new TreeNode(1);
            bn.right=new TreeNode(7);
            //tn.left.right = new TreeNode(2);
            //tn.left.right =new TreeNode(4);
            var self=new treePart();
            //self.LevelOrder(tn);
            //self.MaxDepth(tn);
            //self.IsSymmetric(fn);
            //self.InvertTree(fn);
            //self.HasPathSum(fn,22);
            //self.SearchBST(bn,5);
            var vn= new TreeNode(5);
            vn.left = new TreeNode(4);
            vn.right = new TreeNode(6);
            vn.right.left = new TreeNode(3);
            vn.right.right = new TreeNode(7);

            var fn2=new TreeNode(5);
            fn2.left = new TreeNode(3);
            fn2.left.left = new TreeNode(2);
            fn2.left.right = new TreeNode(4);
            fn2.right = new TreeNode(6);
            fn2.right.right = new TreeNode(7);

            var fn3=new TreeNode(0);
            fn3.left = new TreeNode(-1);
            fn3.left.left = new TreeNode(-3);
            fn3.right = new TreeNode(2);
            fn3.right.right = new TreeNode(4);

            var fn4 = new TreeNode(2);
            fn4.left = new TreeNode(1);
            fn4.right = new TreeNode(3);
            //self.InsertIntoBST(bn, 5);
            //self.IsValidBST(vn);
            self.FindTarget(fn4, 4);
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

        /// <summary>
        /// 翻转二叉树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode InvertTree(TreeNode root)
        {
            if (root==null)
            {
                return null;
            }
            var q=new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count>0)
            {
                var size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    var r = q.Dequeue();
                    var left = r.left;
                    var right = r.right;
                    r.right = left;
                    r.left = right;
                    if (r.left!=null)
                    {
                        q.Enqueue(r.left);
                    }
                    if (r.right!=null)
                    {
                        q.Enqueue(r.right);
                    }
                }
            }
            return root;
        }

        /// <summary>
        /// 路径总和
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root==null)
            {
                return false;
            }
            if (targetSum==0 && (root.left==null&&root.right==null))
            {
                return false;
            }
            var s = new Stack<TreeNode>();
            s.Push(root);
            var li=new List<TreeNode>();
            var linum = new List<int>();
            /*
            while (q.Count>0)
            {
                var node = q.Pop();
                if (!li.Contains(node))
                {
                    linum.Add(node.val);
                }
                if (node.left!=null&&!li.Contains(node.left))
                {
                    q.Push(node.left);
                }
                if (node.right!=null&&!li.Contains(node.right))
                {
                    q.Push(node.right);
                }
                if (li.Contains(node.left) || li.Contains(node.right))
                {
                    if (node.left!=null &&node.right!=null)
                    {
                        if (li.Contains(node.left) && li.Contains(node.right))
                        {
                            linum.RemoveAt(linum.Count-1);
                            li.Add(node);
                        }
                        
                    }
                    else
                    {
                        linum.RemoveAt(linum.Count - 1);
                        li.Add(node);
                    }
                    
                }
                if (node.left==null&& node.right==null)
                {
                    var sum = linum.Sum();
                    if (sum==targetSum)
                    {
                        return true;
                    }
                    linum.Clear();
                    li.Add(node);
                    q.Clear();
                    q.Push(root);
                }
            }
            */
            var used = new List<TreeNode>();
            var sp=new Stack<TreeNode>();
            var t=new TreeNode(10000);
            t.right = root;
            sp.Push(t);
            var sum = 0;
            while (s.Count > 0 && sp.Count>0)
            {
                var node = s.Pop();

                sum = sum + node.val;

                if (node.left!=null)
                {
                    s.Push(node.left);
                }
                if (node.right!=null)
                {
                    s.Push(node.right);
                }

                var pnode = sp.Pop();
                if (pnode.left != null)
                {
                    sp.Push(pnode.left);
                }
                if (pnode.right != null)
                {
                    sp.Push(pnode.right);
                }
                if (node.left==null && node.right==null)
                {
                    Console.WriteLine("sum="+sum);
                    int pval;
                    if (pnode.left==null && pnode.right==null)
                    {
                        pval = 0;
                    }
                    else
                    {
                        pval = pnode.val;
                    }
                    sum = sum - node.val- pval;
                }

                
            }
            return false;
        }

        /// <summary>
        /// 二叉搜索树中的搜索
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root==null)
            {
                return null;
            }

            while (root!=null)
            {
                if (root.val == val)
                {
                    if (root.left==null&&root.right==null)
                    {
                        return null;
                    }
                    return root;
                }
                else
                {
                    if (val<root.val)
                    {
                        root = root.left;
                    }
                    else
                    {
                        root = root.right;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 二叉搜索树中的插入操作
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            var q=new Queue<TreeNode>();
            var pre= new TreeNode();
            if (root == null)
            {
                root = new TreeNode(val);
                return root;
            }
            else
            {
                q.Enqueue(root);
                while (root != null)
                {
                    if (val > root.val)
                    {
                        pre = root;
                        root = root.right;
                    }
                    else
                    {
                        pre = root;
                        root = root.left;
                    }
                }
                if (val > pre.val)
                {
                    pre.right = new TreeNode(val);
                }
                else
                {
                    pre.left = new TreeNode(val);
                }
            }
            return q.Peek();
        }

        /// <summary>
        /// 验证二叉搜索树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root)
        {
            if (root==null)
            {
                return false;
            }
            var q=new Queue<TreeNode>();
            q.Enqueue(root);
            var d=new Dictionary<TreeNode,TreeNode>();
            while (q.Count>0)
            {
                var node = q.Dequeue();
                if (node.left!=null)
                {
                    d.Add(node.left, node);
                    if (node.left.val<node.val)
                    {
                        if (d.ContainsKey(node))
                        {
                            if (node.val>d[node].val && node.left.val<d[node].val)
                            {
                                return false;
                            }
                            else if (node.val<d[node].val && node.val>root.val && d[node].val>root.val && node.left.val<=root.val)
                            {
                                return false;
                            }
                        }
                        
                    }
                    else
                    {
                        return false;
                    }
                    q.Enqueue(node.left);
                }
                if (node.right!=null)
                {
                    d.Add(node.right, node);
                    if (node.right.val > node.val)
                    {
                        if (d.ContainsKey(node))
                        {
                            if (node.val < d[node].val && node.right.val > d[node].val)
                            {
                                return false;
                            }
                            else if (node.val > d[node].val && node.val < root.val && d[node].val < root.val && node.right.val >= root.val)
                            {
                                return false;
                            }
                            else if (node.val>d[node].val && d.ContainsKey(d[node]))
                            {
                                if (d[d[node]].val>d[node].val && node.right.val> d[d[node]].val)
                                {
                                    return false;
                                }
                            }
                        }

                    }
                    else
                    {
                        return false;
                        
                    }
                    q.Enqueue(node.right);
                }
            }
            return true;
            //用中序遍历比较好
        }

        /// <summary>
        /// 两数之和 IV - 输入二叉搜索树
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool FindTarget(TreeNode root, int k)
        {
            if (root==null)
            {
                return false;
            }
            var q1=new Queue<TreeNode>();
            q1.Enqueue(root);
            var q2=new Queue<TreeNode>();
            while (q1.Count>0)
            {
                var node1 = q1.Dequeue();
                var findnum = k - node1.val;
                if (node1.left!=null)
                {
                    q1.Enqueue(node1.left);
                }
                if (node1.right!=null)
                {
                    q1.Enqueue(node1.right);
                }
                foreach (var qq in q1)
                {

                    q2.Enqueue(qq);

                }
                while (q2.Count>0)
                {

                    var node2 = q2.Dequeue();
                    if (node2.val==findnum)
                    {
                        return true;
                    }
                    var bigisroot = findnum > node2.val;
                    if (node2.left!=null && !bigisroot)
                    {
                        q2.Enqueue(node2.left);
                    }
                    if (node2.right!=null && bigisroot)
                    {
                        q2.Enqueue(node2.right);
                    }
                }
            }
            return false;
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
