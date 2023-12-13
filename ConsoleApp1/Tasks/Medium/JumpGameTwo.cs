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
                for (var i = currentNode.NodeValue - 1; i >= 0; i--)
                {
                    if (nums[i] + i >= currentNode.NodeValue
                        && !currentNode.ChildNodes.Any(x => x.Value.NodeValue == i))
                    {
                        if (i == 0)
                        {
                            min = Math.Min(min, currentNode.NodeDepth + 1);

                            if (currentNode.NodeValue == rootNode.NodeValue)
                            {
                                break;
                            }

                            i = rootNode.ChildNodes.Last().Value.NodeValue;
                            currentNode = rootNode;

                            continue;
                        }

                        var newNode = new Node(i, currentNode.NodeDepth + 1);

                        currentNode.ChildNodes.Add(i, newNode);
                        currentNode = newNode;
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
                    ChildNodes = new SortedList<int, Node>();
                }

                public int NodeValue { get; set; }

                public int NodeDepth { get; set; }

                public SortedList<int, Node> ChildNodes { get; set; }
            }
        }
    }
}
