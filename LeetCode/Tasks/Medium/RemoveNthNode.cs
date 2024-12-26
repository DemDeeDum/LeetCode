namespace LeetCode.Tasks.Medium
{
    internal class RemoveNthNode
    {
        /** * Definition for singly-linked list. **/
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        
        public class Solution
        {
            public ListNode RemoveNthFromEnd(ListNode head, int n)
            {
                if (n == 1 && head.next is null)
                {
                    return null;
                }

                var currentNode = head;
                var array = new List<ListNode>(5);

                do
                {
                    array.Add(currentNode);
                    currentNode = currentNode.next;
                }
                while (currentNode is not null);

                if (array.Count - n - 1 >= 0)
                {
                    array[array.Count - n - 1].next = array[array.Count - n].next;
                }
                else
                {
                    head = array[array.Count - n + 1];
                }

                return head;
            }
        }
    }
}
