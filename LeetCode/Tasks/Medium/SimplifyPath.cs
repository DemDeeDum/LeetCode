using System.Text;

namespace LeetCode.Tasks.Medium
{
    internal class SimplifyPath
    {
        public class Solution
        {
            public const char Separator = '/';
            public const char Dote = '.';

            public string SimplifyPath(string path)
            {
                var pathBuilder = new StringBuilder($"{Separator}");
                for (var i = 0; i < path.Length; i++)
                {
                    if (path[i] == Separator)
                    {
                        if (pathBuilder.Length > 0 && pathBuilder[pathBuilder.Length - 1] != Separator)
                        {
                            pathBuilder.Append(Separator);
                        }

                        continue;
                    }
                    else if (path[i] == Dote)
                    {
                        var lastSymbol = i == path.Length - 1;
                        if ((lastSymbol && i > 0 && path[i - 1] == Separator) || (!lastSymbol && path[i + 1] == Separator && (i == 0 || path[i - 1] == Separator))) // single dote => current folder
                        {
                            if (pathBuilder.Length > 0)
                            {
                                pathBuilder.Remove(pathBuilder.Length - 1, 1); // remove last separator
                            }

                            continue;
                        }

                        if (!lastSymbol && path[i + 1] == Dote)
                        {
                            if ((i + 2 > path.Length - 1 || path[i + 2] == Separator) && (i == 0 || path[i - 1] == Separator)) // 2 dots => prev folder
                            {
                                if (pathBuilder.Length > 0)
                                {
                                    pathBuilder.Remove(pathBuilder.Length - 1, 1); // remove separator first
                                    while (pathBuilder.Length > 0 && pathBuilder[pathBuilder.Length - 1] != Separator)
                                    {
                                        pathBuilder.Remove(pathBuilder.Length - 1, 1);
                                    }
                                }
                                
                                i += 2;
                            }
                            else if (i + 2 <= path.Length - 1 && path[i + 2] == Dote) // 3 dots in a row => folder name
                            {
                                pathBuilder.Append($"{Dote}{Dote}{Dote}");

                                i += 2;
                            }
                            else
                            {
                                pathBuilder.Append(path[i]);
                            }

                            continue;
                        }

                        pathBuilder.Append(path[i]);
                    }
                    else
                    {
                        pathBuilder.Append(path[i]);
                    }
                }

                if (pathBuilder.Length > 1 && pathBuilder[pathBuilder.Length - 1] == Separator)
                {
                    pathBuilder.Remove(pathBuilder.Length - 1, 1);
                }

                if (pathBuilder.Length > 0 && pathBuilder[0] != Separator)
                {
                    pathBuilder.Insert(0, Separator);
                }

                if (pathBuilder.Length == 0)
                {
                    pathBuilder.Append(Separator);
                }

                return pathBuilder.ToString();
            }
        }
    }
}
