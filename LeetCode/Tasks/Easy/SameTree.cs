namespace LeetCode.Tasks.Easy
{
    internal class SameTree
    {
        /**
        * Definition for a binary tree node.
        */
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
         
        public class Solution
        {
            public bool IsSameTree(TreeNode p, TreeNode q)
            {
                var pIsNull = p is null;
                var qIsNull = q is null;
                if (pIsNull && qIsNull)
                {
                    return true;
                }

                if (pIsNull != qIsNull || p.val != q.val)
                {
                    return false;
                }

                var pLeftNull = p.left is null;
                var pRightNull = p.right is null;

                var qLeftNull = q.left is null;
                var qRightNull = q.right is null;

                if (pLeftNull != qLeftNull || pRightNull != qRightNull)
                {
                    return false;
                }

                if (!pLeftNull && !IsSameTree(p.left, q.left))
                {
                    return false;
                }

                if (!pRightNull && !IsSameTree(p.right, q.right))
                {
                    return false;
                }

                return true;
            }
        }
    }
}
