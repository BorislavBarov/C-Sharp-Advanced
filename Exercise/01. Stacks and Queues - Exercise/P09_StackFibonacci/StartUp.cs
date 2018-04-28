namespace P09_StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var fib = new Stack<long>();

            fib.Push(0);
            fib.Push(1);
            fib.Push(1);

            for (int i = 2; i < n; i++)
            {
                var s = fib.Pop();
                var f = fib.Pop();
                var x = s + f;

                fib.Push(f);
                fib.Push(s);
                fib.Push(x);
            }

            Console.WriteLine(fib.Peek());
        }
    }
}
