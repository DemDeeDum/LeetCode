namespace LeetCode.Tasks.Medium
{
    internal class TwoSumSortedArray
    {
        public class Solution
        {
            public int[] TwoSum(int[] numbers, int target)
            {
                var arr = new int[numbers.Length];
                var filled = 0;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] <= target || numbers[i] == 0 || target == 0)
                    {
                        for (var j = 0; j < filled; j++)
                        {
                            if (numbers[i] + numbers[arr[j]] == target)
                            {
                                return new[] { arr[j] + 1, i + 1 };
                            }
                        }

                        arr[filled] = i;
                        filled++;
                    }
                }

                return new int[1]; 
            }
        }
    }
}
