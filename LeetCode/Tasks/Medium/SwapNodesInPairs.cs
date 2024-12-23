namespace LeetCode.Tasks.Medium
{
    internal class SwapNodesInPairs
    {
        /**
        * Definition for singly-linked list.
        **/
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
            public ListNode SwapPairs(ListNode head)
            {
                if (head == null || head.next == null)
                {
                    return head;
                }

                var savedHead = head.next;
                ListNode? prev = null;
                while(head.next != null)
                {
                    var savedNext = head.next;
                    head.next = savedNext.next;
                    savedNext.next = head;
                    if (prev != null)
                    {
                        prev.next = savedNext;
                    }

                    if (head.next != null)
                    {
                        prev = head;
                        head = head.next;
                    }
                }

                return savedHead;
            }
        }
    }
}
