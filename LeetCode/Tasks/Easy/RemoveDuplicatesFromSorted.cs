namespace LeetCode.Tasks.Easy
{
    internal class RemoveDuplicatesFromSorted
    {
        public class Solution
        {
            public int RemoveDuplicates(int[] nums)
            {
                if (nums.Length == 0)
                {
                    return 0;
                }

                var numberOfDuplicated = 0;
                var buffer = new int[nums.Length];
                var bufferIndex = 0;

                for (var frontIndex = 0; frontIndex < nums.Length; frontIndex++)
                {
                    var increment = 0;
                    for(var searchedIndex = frontIndex + 1; searchedIndex < nums.Length; searchedIndex++)
                    {
                        if (nums[frontIndex] == nums[searchedIndex])
                        {
                            increment++;
                        }
                    }

                    buffer[bufferIndex++] = nums[frontIndex];
                    frontIndex += increment;
                    numberOfDuplicated += increment;
                }

                buffer.CopyTo(nums, 0);

                return nums.Length - numberOfDuplicated;
            }
        }
    }
}
