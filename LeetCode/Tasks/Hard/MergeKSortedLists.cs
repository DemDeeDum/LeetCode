namespace LeetCode.Tasks.Hard
{
    internal class MergeKSortedLists
    {
        /**
         * Definition for singly-linked list. */
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
            public ListNode MergeKLists(ListNode[] lists)
            {
                ListNode? head = null;
                ListNode? tail = null;
                var someHasLinkToNext = true;
                while (someHasLinkToNext)
                {
                    someHasLinkToNext = false;
                    var indexOfMin = -1;
                    ListNode? min = null;
                    for (var i = 0; i< lists.Length; i++)
                    {
                        if (lists[i] != null && (min is null || min.val > lists[i].val))
                        {
                            min = lists[i];
                            indexOfMin = i;
                            someHasLinkToNext = true;
                        }
                    }

                    if (min is not null)
                    {
                        tail = Append(tail, min.val);
                        if (head is null)
                        {
                            head = tail;
                        }

                        lists[indexOfMin] = lists[indexOfMin].next;
                        min = null;
                        indexOfMin = -1;
                    }
                }

                return head!;
            }

            private ListNode Append(ListNode? tail, int value)
            {
                var newNode = new ListNode(value);
                if (tail is not null)
                {
                    tail.next = newNode;
                }

                return newNode;
            }
        }
    }
}
