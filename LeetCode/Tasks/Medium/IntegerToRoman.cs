using System.Text;

namespace LeetCode.Tasks.Medium
{
    public class IntegerToRoman
    {
        public class Solution
        {
            private const char One = 'I';
            private const char Five = 'V';
            private const char Ten = 'X';
            private const char Fifty = 'L';
            private const char Hundread = 'C';
            private const char FiveHundread = 'D';
            private const char Thousand = 'M';

            public string IntToRoman(int num)
            {
                var romanInterpretation = new StringBuilder();
                romanInterpretation.Insert(0, RetrievePart(ref num, One, Five, Ten));
                romanInterpretation.Insert(0, RetrievePart(ref num, Ten, Fifty, Hundread));
                romanInterpretation.Insert(0, RetrievePart(ref num, Hundread, FiveHundread, Thousand));
                romanInterpretation.Insert(0, new string(Thousand, num));

                return romanInterpretation.ToString();
            }

            private StringBuilder RetrievePart(ref int number, char one, char five, char ten)
            {
                var part = number % 10;
                number /= 10;

                var builder = new StringBuilder();
                if (part < 4)
                {
                    return builder.Append(new string(one, part));
                }
                else if (part == 4)
                {
                    return builder
                        .Append(one)
                        .Append(five);
                }
                else if (part < 9)
                {
                    return builder.Append(five).Append(new string(one, part - 5));
                }
                else
                {
                    return builder.Append(one).Append(ten);
                }
            }
        }
    }
}
