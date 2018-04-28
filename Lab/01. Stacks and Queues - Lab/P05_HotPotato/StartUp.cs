namespace P05_HotPotato
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var children = Console.ReadLine().Split();
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(children);

            var counter = 0;

            while (queue.Count > 1)
            {
                counter++;

                if (counter == n)
                {
                    counter = 0;
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }
                else
                {
                    var currentChild = queue.Dequeue();
                    queue.Enqueue(currentChild);
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
