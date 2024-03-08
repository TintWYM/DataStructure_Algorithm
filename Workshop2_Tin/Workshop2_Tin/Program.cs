namespace Workshop2_Tin;

class Program
{
    public static void Main()
    {
        Console.WriteLine(IsBalancedDelimiter("a {b [c (d + e)/2 - f  ] + 1}"));
        Console.WriteLine(IsBalancedDelimiter("a {b [c (d + e)/2 - f  ] + 1"));
        Console.WriteLine(IsBalancedDelimiter("{a [b + (c + 2)/d ] + e) + f }"));
    }

    public static bool IsBalancedDelimiter(string expression)
    {
        Stack<char> openDelimiterStack = new Stack<char>();

        foreach (char ch in expression)
        {
            if (IsOpenDelimiter(ch))
            {
                openDelimiterStack.Push(ch);
            }
            else if (IsCloseDelimiter(ch))
            {
                if (openDelimiterStack.Count > 0)
                {
                    char openDelimiterFromStack = openDelimiterStack.Pop();
                    if (IsPaired(openDelimiterFromStack, ch))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        if (openDelimiterStack.Count == 0)
            return true;
        else
            return false;
    }

    private static bool IsOpenDelimiter(char ch)
    {
        return (ch == '(' || ch == '[' || ch == '{');
    }

    private static bool IsCloseDelimiter(char ch)
    {
        return (ch == ')' || ch == ']' || ch == '}');
    }

    private static bool IsPaired(char openDelimiterFromStack, char closedDelimiter)
    {
        return (openDelimiterFromStack == '(' && closedDelimiter == ')') ||
            (openDelimiterFromStack == '[' && closedDelimiter == ']') ||
            (openDelimiterFromStack == '{' && closedDelimiter == '}');

    }
}