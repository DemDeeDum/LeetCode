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
                var current = head;
                var index = 0;
                var tempHead = current;
                var tempCurrent = current;
                var shouldStop = false;
                ListNode? prevTail = null;

                while (current != null)
                {
                    index = 1;
                    var kCheck = current;
                    while (index++ < k)
                    {
                        kCheck = kCheck.next;
                        if (kCheck is null)
                        {
                            shouldStop = true;

                            break;
                        }
                    }

                    if (shouldStop)
                    {
                        break;
                    }

                    index = 1;
                    tempHead = current;
                    tempCurrent = current;

                    while (index < k)
                    {
                        var next = tempCurrent.next;

                        tempCurrent.next = next.next;
                        next.next = tempHead;
                        tempHead = next;
                        if (prevTail is not null)
                        {
                            prevTail.next = tempHead;
                        }

                        index++;
                    }

                    current = tempCurrent.next;
                    prevTail = tempCurrent;
                    if (newHead is null)
                    {
                        newHead = tempHead;
                    }
                }

                return newHead ?? head;
            }
        }
    }
}
