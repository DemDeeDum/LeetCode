namespace LeetCode.Tasks.Medium
{
    internal class CopyListWithRandomPointer
    {
        // Definition for a Node.
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }

        public class Solution
        {
            public Node CopyRandomList(Node head)
            {
                if (head is null)
                {
                    return null;
                }

                var newHead = new Node(head.val);
                var currentNode = head;
                var currentNewNode = newHead;
                var randomNodeToNodesAndNewVersion = new Dictionary<Node, Data>();
                while (currentNode != null)
                {
                    if (currentNode.random != null)
                    {
                        if (randomNodeToNodesAndNewVersion.TryGetValue(currentNode.random, out var data))
                        {
                            if (data.NewVersion != null)
                            {
                                currentNewNode.random = data.NewVersion;
                            }
                            else
                            {
                                data.AllOwners.Add(currentNewNode);
                            }
                        }
                        else
                        {
                            randomNodeToNodesAndNewVersion.Add(currentNode.random, new Data { AllOwners = new List<Node> { currentNewNode } });
                        }
                    }

                    if (randomNodeToNodesAndNewVersion.TryGetValue(currentNode, out var tuple))
                    {
                        tuple.NewVersion = currentNewNode;
                        foreach (var node in tuple.AllOwners)
                        {
                            node.random = currentNewNode;
                        }
                    }
                    else
                    {
                        randomNodeToNodesAndNewVersion.Add(currentNode, new Data { AllOwners = new List<Node>(), NewVersion = currentNewNode });
                    }

                    currentNode = currentNode.next;
                    if (currentNode != null)
                    {
                        var newNode = new Node(currentNode.val);
                        currentNewNode.next = newNode;
                        currentNewNode = newNode;
                    }
                }

                return newHead;
            }

            class Data
            {
                public List<Node> AllOwners;

                public Node NewVersion;
            }
        }
    }
}