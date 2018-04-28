namespace P10_SimpleTextEditor
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var text = string.Empty;
            var stack = new Stack<string>();
            stack.Push(text);

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var command = line[0];

                switch (command)
                {
                    case "1":
                        var someString = line[1];
                        text += someString;
                        stack.Push(text);
                        break;

                    case "2":
                        var count = int.Parse(line[1]);
                        text = text.Remove(text.Length - count, count);
                        stack.Push(text);
                        break;

                    case "3":
                        var index = int.Parse(line[1]);
                        Console.WriteLine(text[index - 1]);
                        break;

                    case "4":
                        stack.Pop();
                        text = stack.Peek();
                        break;
                }
            }
        }
    }
}
