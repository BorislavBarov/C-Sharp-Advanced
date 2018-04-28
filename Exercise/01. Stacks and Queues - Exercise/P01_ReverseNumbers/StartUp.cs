namespace P01_ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            var stack = new Stack<int>(input);
            
            while (stack.Count > 1)
            {
                Console.Write(stack.Pop() + " ");
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
