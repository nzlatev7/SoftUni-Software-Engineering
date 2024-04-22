using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class SameTree
    {
        public static bool OneLineSolution(TreeNode p, TreeNode q)
        {
            // ??= - also make assignment
            // ?? - return the value

            //TreeNode value = p ?? q;
            //// [1,2], [1,2] -> true
            //// null, [1,2] -> false
            //// [1,2], null -> false
            //return (p ?? q) == null;

            // not null, diff values -> [1,2,3], [2,2,3] -> working fine

            return (p ?? q) == null
                   || p?.val == q?.val
                   && OneLineSolution(p.left, q.left)
                   && OneLineSolution(p.right, q.right);
        }
        public static bool MineIsSameTree(TreeNode p, TreeNode q)
        {
            TreeNode pLeft = p.left;
            TreeNode pRight = p.right;

            TreeNode qLeft = q.left;
            TreeNode qRight = q.right;

            // 1,2
            // 1, null, 2
            while (p.right != null && q.right != null)
            {
                if (p.val == q.val)
                {
                    p = p.right;
                    q = q.right;
                }
                else
                {
                    return false;
                }
            }

            if (p.val == q.val)
            {
                return true;
            }

            return false;
        }

        // recursive way
        // p = [1,2,3], q = [1,2,3] -> true
        // p = [1,2], q = [1,null,2] -> false
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            // how it is possible to second = null - because is it a tree structure

            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            bool isSame1 = false;
            bool isSame2 = false;

            if (p.val == q.val)
            {
                isSame1 = IsSameTree(p.left, q.left);
                isSame2 = IsSameTree(p.right, q.right);
            }

            return isSame1 && isSame2;
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
