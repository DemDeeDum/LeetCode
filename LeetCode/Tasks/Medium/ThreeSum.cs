namespace LeetCode.Tasks.Medium
{
    internal class ThreeSum
    {
        public class Solution
        {
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                Array.Sort(nums);
                var result = GetNumbers(nums, Enumerable.Empty<int>(), -1, 3, 1);

                return result;
            }

            private IList<IList<int>> GetNumbers(int[] nums, IEnumerable<int> previousNumbers, int index, int amountOfNumbers, int currentDeep)
            {
                List<IList<int>> results = new List<IList<int>>();
                var lastIteration = amountOfNumbers == currentDeep;
                var totalSum = 0;
                if (lastIteration)
                {
                    totalSum = previousNumbers.Sum();
                }

                for (var i = index + 1; i < nums.Length - amountOfNumbers + currentDeep; i++)
                {
                    if (lastIteration)
                    {
                        if (totalSum + nums[i] == 0)
                        {
                            results.Add(previousNumbers.Append(nums[i]).ToList());
                        }
                    }
                    else
                    {
                        foreach (var list in GetNumbers(nums, previousNumbers.Append(nums[i]), i, amountOfNumbers, currentDeep + 1))
                        {
                            if (!results.Any(x => Enumerable.SequenceEqual(x, list)))
                            {
                                results.Add(list);
                            }
                        }
                    }
                }

                return results;
            }
        }
    }
}
