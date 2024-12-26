namespace LeetCode.Tasks.Hard
{
    internal class ReverseNodesInKGroup
    {
        /** Definition for singly-linked list. **/
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
            public ListNode ReverseKGroup(ListNode head, int k)
            {
                ListNode? newHead = null;
                ListNode? currentNew = null;
                var current = head;
                var shouldStop = false;
                var index = 0;
                var tempHead = current;
                var tempTail = current;
                var savedNext = current;

                while (current != null)
                {
                    index = 0;
                    tempHead = current;
                    tempTail = current;
                    current = savedNext;
                    while (index < k)
                    {
                        var savedHead = tempHead;
                        tempHead = current.next;
                        if (tempHead is null)
                        {
                            shouldStop = true;

                            break;
                        }

                        savedNext = tempHead.next;
                        tempHead.next = savedHead;
                        current.next = current;

                        index++;
                    }

                    if (currentNew == null)
                    {
                        newHead = tempHead;
                        currentNew = tempHead;
                    }
                    
                    if (shouldStop)
                    {
                        while (current != null)
                        {
                            currentNew.next = current;
                            current = current.next;
                        }
                    }
                    else
                    {
                        currentNew.next = tempHead;
                        currentNew = tempTail;
                        current =
                    }
                }

                return newHead;
            }
        }
    }
}
