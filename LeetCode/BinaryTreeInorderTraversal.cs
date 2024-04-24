using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class BinaryTreeInorderTraversal
    {
        // depth-first -> stack
        // breadth first -> queue

        // InorderTraversal -> depth-first search algorithm, first traverses the left subtree, second the root, last the right subtree
        // [1,null,2,3] -> 
        public static IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }

            List<int> vals = new List<int>();

            vals.AddRange(InorderTraversal(root.left));
            vals.Add(root.val);
            vals.AddRange(InorderTraversal(root.right));

            return vals;
        }
    }

    //Definition for a binary tree node.
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
