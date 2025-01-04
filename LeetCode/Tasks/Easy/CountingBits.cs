namespace LeetCode.Tasks.Easy
{
    internal class CountingBits
    {
        public class Solution
        {
            public int[] CountBits(int n)
            {
                // Dp
                var result = new int[n + 1];
                result[1] = 1;
                var matrix = new int[n / 2, n / 2];
                for (var i = 0; i < n - 1; i++)
                {
                    var added = false;
                    for (var j = 0; j < n - 1; j++)
                    {
                        if (!added)
                        {
                            if (matrix[i - 1, j] == 0)
                            {
                                result[i]++;
                                matrix[i, j] = 1;
                                added = true;
                            }
                        }
                        else
                        {
                            matrix[i, j] = matrix[i - 1, j];
                            if (matrix[i, j] == 1)
                            {
                                result[i]++;
                            }
                        }
                    }
                }

                return result;
                
                // Non dp
                //var result = new int[n + 1];
                //for (var  i = 1; i <= n; i++)
                //{
                //    result[i] = CountNumberOfOnes(i);
                //}

                //return result;
            }

            private int CountNumberOfOnes(int number)
            {
                if (number == 1)
                {
                    return 1;
                }

                var degree = 0;
                var savedNumber = number;
                while (savedNumber != 1)
                {
                    savedNumber /= 2;
                    degree++;
                }

                var result = 1;

                var left = number - (int)Math.Pow(2, degree);
                if (left > 0)
                {
                    result += CountNumberOfOnes(left);
                }

                return result;
            }
        }
    }
}
