namespace LeetCode.Tasks.Easy
{
    internal class HappyNumber
    {
        public class Solution
        {
            public bool IsHappy(int n)
            {
                var numbers = new List<int>();
                while (n != 0)
                {
                    numbers.Add(n % 10);
                    n /= 10;
                }

                if (numbers.Count == 1 && numbers[0] != 1 && numbers[0] < 7)
                {
                    return false;
                }

                var sum = 0;
                foreach (var item in numbers)
                {
                    sum += item * item;
                }

                if (sum == 1)
                {
                    return true;
                }
                else
                {
                    return IsHappy(sum);
                }
            }
        }
    }
}
