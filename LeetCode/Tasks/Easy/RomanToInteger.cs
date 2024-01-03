namespace LeetCode.Tasks.Easy
{
    internal class RomanToInteger
    {
        public class Solution
        {
            private readonly Dictionary<char, int> _matches = new()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 },
            };

            public int RomanToInt(string s)
            {
                var translated = TranslateRange(s);

                return translated;
            }

            private int TranslateRange(string subString)
            {
                var value = 0;
                var largests = new List<(char Value, int Number, int Index)>();
                for (var i = 0; i < subString.Length; i++)
                {
                    if (_matches.TryGetValue(subString[i], out var number))
                    {
                        var largestNumber = largests.FirstOrDefault().Number;
                        if (largestNumber < number)
                        {
                            largests.Clear();
                        }
                        else if (largestNumber > number)
                        {
                            continue;
                        }

                        largests.Add((subString[i], number, i));
                    }
                }

                if (!largests.Any())
                {
                    return value;
                }

                for (var i = 0; i < largests.Count; i++)
                {
                    var toAddBegginingIndex = i == largests.Count - 1 && largests[i].Index < subString.Length - 1 ? largests[i].Index + 1 : -1;
                    var toAddLenght = toAddBegginingIndex == - 1 ? -1 : subString.Length - toAddBegginingIndex ;
                    var toAdd = toAddBegginingIndex == -1 ? string.Empty : subString.Substring(toAddBegginingIndex, toAddLenght);
                    value += largests[i].Number + TranslateRange(toAdd);

                    var toSubstractBeginningIndex = largests[i].Index > 0 
                        ? i > 0
                        ? largests[i - 1].Index + 1
                        : 0
                        : -1;
                    var toSubstractLength = toSubstractBeginningIndex == -1 ? -1 : largests[i].Index - toSubstractBeginningIndex;
                    var toSubstract = toSubstractBeginningIndex == -1 ? string.Empty : subString.Substring(toSubstractBeginningIndex, toSubstractLength);
                    value -= TranslateRange(toSubstract);
                }

                return value;
            }
        }
    }
}
