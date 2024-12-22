namespace LeetCode.Tasks.Medium
{
    internal class CountNicePairsInArray
    {
        public class Solution
        {
            const int MOD = 1_000_000_007;
            public int CountNicePairs(int[] nums)
            {
                decimal numberOfPairs = 0;
                var dictionaryResult = new Dictionary<int, int>();
                for (var i = 0; i < nums.Length; i++)
                {
                    nums[i] = ReturnDifferenceIfReversed(nums[i]);
                    if (dictionaryResult.TryGetValue(nums[i], out var value))
                    {
                        numberOfPairs += value;
                        dictionaryResult[nums[i]]++;
                    }
                    else
                    {
                        dictionaryResult.Add(nums[i], 1);
                    }
                }

                return (int)(numberOfPairs % MOD);
            }

            private int ReturnDifferenceIfReversed(int number)
            {
                if (number < 10)
                {
                    return 0;
                }

                var initialNumber = number;
                var newNumber = 0;
                do
                {
                    newNumber = newNumber * 10 + number % 10;
                    number /= 10;
                }
                while (number > 0);

                return newNumber - initialNumber;
            }
        }
    }
}
