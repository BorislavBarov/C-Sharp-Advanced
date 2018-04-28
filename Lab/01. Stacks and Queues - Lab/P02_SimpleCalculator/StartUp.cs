namespace P02_SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Reverse().ToArray();

            var stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                var leftNumber = int.Parse(stack.Pop());
                var operation = stack.Pop();
                var rightNumber = int.Parse(stack.Pop());

                switch (operation)
                {
                    case "+":
                        stack.Push((leftNumber + rightNumber).ToString());
                        break;
                    case "-":
                        stack.Push((leftNumber - rightNumber).ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
