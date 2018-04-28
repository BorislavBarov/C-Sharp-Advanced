﻿namespace P03_DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }

            var stack = new Stack<int>();

            while (number > 0)
            {
                stack.Push(number % 2);

                number /= 2;
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
