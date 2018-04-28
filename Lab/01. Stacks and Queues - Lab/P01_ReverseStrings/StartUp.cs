namespace P01_ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var inputString = Console.ReadLine();

            var stack = new Stack<char>();

            foreach (var symbol in inputString)
            {
                stack.Push(symbol);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
