namespace LeetCode.Tasks.Medium
{
    public class JumpGameTwo
    {
        public class Solution
        {
            public int Jump(int[] nums)
            {
                if (!nums.Any() || nums.Length == 1)
                {
                    return 0;
                }

                var min = int.MaxValue;
                var rootNode = new Node(nums.Length - 1, 0);

                var currentNode = rootNode;
                var maxStep = 0;
                for (var i = currentNode.NodeValue - 1; i >= 0; i--)
                {
                    if (nums[i] + i >= currentNode.NodeValue)
                    {
                        if (i == 0)
                        {
                            min = Math.Min(min, currentNode.NodeDepth + 1);
                            break;
                        }

                        maxStep = i;
                    }
                    
                    if (i == 0)
                    {
                        var newNode = new Node(maxStep, currentNode.NodeDepth + 1);

                        currentNode = newNode;
                        maxStep = 0;
                        i = currentNode.NodeValue;
                    }
                }

                return min;
            }

            private class Node
            {
                public Node(int nodeValue, int nodeDepth)
                {
                    NodeValue = nodeValue;
                    NodeDepth = nodeDepth;
                }
                /// <summary>
                /// Index
                /// </summary>
                public int NodeValue { get; set; }

                public int NodeDepth { get; set; }
            }
        }
    }
}
