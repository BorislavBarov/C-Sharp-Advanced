namespace P07_BalancedParenthesis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var openedParentheses = new Stack<char>();
            var openingCases = new char[] { '{', '[', '(' };

            for (int i = 0; i < input.Length; i++)
            {
                if (openingCases.Contains(input[i]))
                {
                    openedParentheses.Push(input[i]);
                }
                else
                {
                    if (openedParentheses.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else
                    {
                        switch (input[i])
                        {
                            case '}':
                                if (openedParentheses.Pop() != '{')
                                {
                                    Console.WriteLine("NO");
                                    return;
                                }
                                break;

                            case ']':
                                if (openedParentheses.Pop() != '[')
                                {
                                    Console.WriteLine("NO");
                                    return;
                                }
                                break;

                            case ')':
                                if (openedParentheses.Pop() != '(')
                                {
                                    Console.WriteLine("NO");
                                    return;
                                }
                                break;
                        }
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
