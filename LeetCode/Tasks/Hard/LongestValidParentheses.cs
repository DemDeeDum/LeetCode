namespace LeetCode.Tasks.Hard
{
    public class LongestValidParenthesesClass
    {
        public class Solution
        {
            const char Beginning = '(';
            const char Ending = ')';

            public int LongestValidParentheses(string s)
            {
                //return CustomSolution(s);
                return DPTry(s);
            }

            private int DPTry(string s)
            {
                var max = 0;
                var memo = new int[s.Length];
                for (var j = 1; j < s.Length; j++)
                {
                    if (s[j] == Ending)
                    {
                        if (s[j - 1] == Beginning)
                        {
                            memo[j] = (j > 2 ? memo[j - 2] : 0) + 2;
                        }
                        else if (j - memo[j - 1] > 0 && s[j - memo[j - 1] - 1] == Beginning)
                        {
                            memo[j] = j - (memo[j - 1] + 2) > 0
                                ? memo[j - memo[j - 1] - 2] + memo[j - 1] + 2
                                : memo[j - 1] + 2;
                        }

                        max = Math.Max(memo[j], max);
                    }
                }

                return max;
            }

            private int CustomSolution(string s)
            {
                var current = 0;
                var max = 0;
                var stack = new int[s.Length];
                var count = 0;
                var indexBeginning = -1;
                for (var j = 0; j < s.Length; j++)
                {
                    if (s[j] == Beginning)
                    {
                        stack[count] = 1;
                        indexBeginning = count;
                        count++;
                    }
                    else if (s[j] == Ending)
                    {
                        if (indexBeginning != -1)
                        {
                            stack[indexBeginning]++;

                            var somethingBehindToClose = false;
                            while (indexBeginning > 0)
                            {
                                indexBeginning--;

                                if (stack[indexBeginning] == 1)
                                {
                                    somethingBehindToClose = true;

                                    break;
                                }
                            }

                            if (!somethingBehindToClose)
                            {
                                indexBeginning = -1;
                            }
                        }
                        else
                        {
                            for (var i = 0; i < count; i++)
                            {
                                if (stack[i] == 2)
                                {
                                    current += 2;
                                }
                                else
                                {
                                    max = Math.Max(max, current);
                                    current = 0;
                                }
                            }

                            count = 0;
                            max = Math.Max(max, current);
                            current = 0;
                        }
                    }
                }

                for (var i = 0; i < count; i++)
                {
                    if (stack[i] == 2)
                    {
                        current += 2;
                    }
                    else
                    {
                        max = Math.Max(max, current);
                        current = 0;
                    }
                }

                max = Math.Max(max, current);

                return max;
            }
        }
    }
}
