namespace LeetCode.Tasks.Medium
{
    internal class RemoveDuplicatesFromSortedTwo
    {
        public class Solution
        {
            public int RemoveDuplicates(int[] nums)
            {
                var numberOfDuplicates = 0;
                for (var index = 0; index < nums.Length - numberOfDuplicates; index++)
                {
                    var found = false;
                    for (var i = index + 1; i < nums.Length - numberOfDuplicates; i++)
                    {
                        if (nums[i] == nums[index])
                        {
                            if (!found)
                            {
                                found = true;

                                continue;
                            }

                            MakeAShift(nums, i);
                            numberOfDuplicates++;
                            i--;
                        }
                    }
                }

                return nums.Length - numberOfDuplicates;
            }

            public void MakeAShift(int[] nums, int indexToShiftFrom)
            {
                var valueToPlaceToEnd = nums[indexToShiftFrom];
                for(var i = indexToShiftFrom; i < nums.Length - 1; i++)
                {
                    nums[i] = nums[i + 1];
                }

                nums[nums.Length - 1] = valueToPlaceToEnd;
            }
        }
    }
}
