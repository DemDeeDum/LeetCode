using System.Diagnostics.CodeAnalysis;

namespace LeetCode.Tasks.Medium
{
    internal class UniqueBinarySearchTreeTwo
    {
        /**
         * Definition for a binary tree node.
         * */
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
            public IList<TreeNode> GenerateTrees(int n)
            {
                var treeNodes = new List<TreeNode>();
                var allValues = Enumerable.Range(1, n).ToArray();
                for (var i = 0; i < allValues.Length; i++)
                {
                    var rootNode = new TreeNode(allValues[i]);
                    var listOfTrees = new List<TreeNode> { rootNode };
                    CreateTrees(rootNode, GetArrayWithoutValue(allValues, i), listOfTrees, 1);
                    treeNodes.AddRange(listOfTrees);
                }

                return treeNodes.Distinct(new TreeComparer()).ToList();
            }

            private void CreateTrees(TreeNode root, int[] arrayOfAllValues, List<TreeNode> treeNodes, int deepness)
            {
                var savedRoot = CopyTree(root);
                for (var i = 0; i < arrayOfAllValues.Length; i++)
                {
                    if (i == arrayOfAllValues.Length - 1 && arrayOfAllValues.Length != 1)
                    {
                        root = savedRoot;
                        treeNodes.Add(root);
                    }            
                    else if (i > 0)
                    {
                        root = CopyTree(savedRoot);
                        treeNodes.Add(root);
                    }

                    AddElementToTheTree(new TreeNode(arrayOfAllValues[i]), root);
                    var arrayWithoutI = GetArrayWithoutValue(arrayOfAllValues, i);
                    for (var j = i; j < arrayWithoutI.Length; j++)
                    {
                        if (AddElementToTheTree(new TreeNode(arrayWithoutI[j]), root, 1, deepness))
                        {
                            i++;
                            arrayWithoutI = GetArrayWithoutValue(arrayWithoutI, j);
                        }
                    }

                    CreateTrees(root, arrayWithoutI, treeNodes, deepness + 1);
                }
            }

            private bool AddElementToTheTree(TreeNode newNode, TreeNode root, int currentDeepness = 1, int? targetDeepness = null)
            {
                if (root.val > newNode.val)
                {
                    if (root.left is null)
                    {
                        root.left = newNode;

                        return true;
                    }
                    else if (!targetDeepness.HasValue || currentDeepness > targetDeepness)
                    {
                        AddElementToTheTree(newNode, root.left, currentDeepness + 1, targetDeepness);

                        return true;
                    };
                }
                else
                {
                    if (root.right is null)
                    {
                        root.right = newNode;

                        return true;
                    }
                    else if (!targetDeepness.HasValue || currentDeepness > targetDeepness)
                    {
                        AddElementToTheTree(newNode, root.right, currentDeepness + 1, targetDeepness); ;

                        return true;
                    }
                }

                return false;
            }

            private int[] GetArrayWithoutValue(int[] arrayOfAllValue, int i)
            {
                var newArray = new int[arrayOfAllValue.Length - 1];
                for (int j = 0, k = 0; j < newArray.Length; k++, j++)
                {
                    if (k == i)
                    {
                        k++;
                    }

                    newArray[j] = arrayOfAllValue[k];
                }

                return newArray;
            }

            private TreeNode CopyTree(TreeNode root)
            {
                var newRoot = new TreeNode(root.val);
                if (root.left is not null)
                {
                    newRoot.left = CopyTree(root.left);
                }

                if (root.right is not null)
                {
                    newRoot.right = CopyTree(root.right);
                }

                return newRoot;
            }

            private class TreeComparer : IEqualityComparer<TreeNode>
            {
                public bool Equals(TreeNode? rootOne, TreeNode? rootTwo)
                {
                    if (rootOne.val != rootTwo.val)
                    {
                        return false;
                    }

                    var oneLeftNull = rootOne.left is null;
                    var twoLeftNull = rootTwo.left is null;
                    var oneRightNull = rootOne.right is null;
                    var twoRightNull = rootTwo.right is null;

                    if (oneLeftNull != twoLeftNull || oneRightNull != twoRightNull)
                    {
                        return false;
                    }

                    if (!oneLeftNull && !Equals(rootOne.left, rootTwo.left))
                    {
                        return false;
                    }

                    if (!oneRightNull && !Equals(rootOne.right, rootTwo.right))
                    {
                        return false;
                    }

                    return true;
                }

                public int GetHashCode([DisallowNull] TreeNode obj)
                {
                    return 1;
                }
            }
        }
    }
}
