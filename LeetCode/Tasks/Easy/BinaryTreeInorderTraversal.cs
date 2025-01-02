namespace LeetCode.Tasks.Easy
{
    internal class BinaryTreeInorderTraversal
    {
        /**
        * Definition for a binary tree node.*/
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
            public IList<int> InorderTraversal(TreeNode root)
            {
                var list = new List<int>();
                Recursive(root, list);

                return list;
            }

            private void Recursive(TreeNode node, List<int> list)
            {
                if (node is null)
                {
                    return;
                }

                if (node.left is not null)
                {
                    Recursive(node.left, list);
                }

                list.Add(node.val);

                if (node.right is not null)
                {
                    Recursive(node.right, list);
                }
            }
        }
    }
}
