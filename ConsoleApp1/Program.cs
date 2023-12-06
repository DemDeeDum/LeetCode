class Program
{
    public static void Main()
    {
    }
}

public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var firstIndex = 0;
        var secondIndex = 0;
        var finalIndex = 0;
        var finalArray = new int[n + m];
        while (finalIndex < n + m)
        {
            if (firstIndex < m && (secondIndex >= n || nums1[firstIndex] < nums2[secondIndex]))
            {
                finalArray[finalIndex] = nums1[firstIndex++];
            }
            else
            {
                finalArray[finalIndex] = nums2[secondIndex++];
            }

            finalIndex++;
        }

        finalArray.CopyTo(nums1, 0);
    }

    public int RemoveElement(int[] nums, int val)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        var numberOfEntrance = 0;
        var frontIndex = 0;
        var backIndex = nums.Length - 1;

        while (frontIndex <= backIndex)
        {
            if (nums[frontIndex] == val)
            {
                numberOfEntrance++;

                if (!UpdateBackIndex(nums, frontIndex, ref backIndex, ref numberOfEntrance, val))
                {
                    break;
                }

                nums[frontIndex] = nums[backIndex];
                nums[backIndex] = val;

                backIndex--;
            }

            frontIndex++;
        }

        UpdateBackIndex(nums, frontIndex, ref backIndex, ref numberOfEntrance, val);

        return nums.Length - numberOfEntrance;
    }

    private bool UpdateBackIndex(int[] nums, int frontIndex, ref int backIndex, ref int numberOfEntrance, int val)
    {
        while (backIndex >= 0 && frontIndex != backIndex && nums[backIndex] == val)
        {
            numberOfEntrance++;
            backIndex--;
        }

        return backIndex >= 0;
    }
}