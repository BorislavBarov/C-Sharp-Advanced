namespace P03_MaximumElement
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var maxElements = new Stack<int>();
            var max = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                if (line.StartsWith("1"))
                {
                    var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var number = int.Parse(parts[1]);

                    stack.Push(number);

                    if (number > max)
                    {
                        max = number;
                        maxElements.Push(max);
                    }
                }
                else if (line == "2")
                {
                    if (stack.Pop() == maxElements.Peek())
                    {
                        maxElements.Pop();

                        if (maxElements.Count != 0)
                        {
                            max = maxElements.Peek();
                            continue;
                        }

                        max = int.MinValue;
                    }
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(maxElements.Peek());
                    }
                }
            }
        }
    }
}
