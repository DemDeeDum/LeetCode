namespace LeetCode.Tasks.Easy
{
    internal class MergeSortedLinkedLists
    {
        /** Definition for singly-linked list.**/
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
            public ListNode MergeTwoLists(ListNode list1, ListNode list2)
            {
                var currentOne = list1;
                var currentTwo = list2;
                ListNode head = null!;
                var listOneNull = list1 is null;
                var listTwoNull = list2 is null;

                if (currentTwo is null)
                {
                    head = currentOne;
                    if (currentOne is not null)
                    {
                        currentOne = currentOne.next;
                    }
                }
                else if (currentOne is null)
                {
                    head = currentTwo;
                    if (currentTwo is not null)
                    {
                        currentTwo = currentTwo.next;
                    }
                }
                else if (currentOne.val > currentTwo.val)
                {
                    head = currentTwo;
                    currentTwo = currentTwo.next;
                }
                else
                {
                    head = currentOne;
                    currentOne = currentOne.next;
                }

                var current = head;
                while (currentOne != null || currentTwo != null)
                {
                    if (currentTwo is null)
                    {
                        current.next = currentOne;
                        if (currentOne is not null)
                        {
                            currentOne = currentOne.next;
                        }
                    }
                    else if (currentOne is null)
                    {
                        current.next = currentTwo;
                        if (currentTwo is not null)
                        {
                            currentTwo = currentTwo.next;
                        }
                    }
                    else if (currentOne.val > currentTwo.val)
                    {
                        current.next = currentTwo;
                        currentTwo = currentTwo.next;
                    }
                    else
                    {
                        current.next = currentOne;
                        currentOne = currentOne.next;
                    }

                    current = current.next;
                }

                return head;
            }
        }
    }
}
