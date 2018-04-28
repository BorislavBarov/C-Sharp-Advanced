namespace P06_TrafficJam
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<string>();

            int counter = 0;
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    var count = Math.Min(n, queue.Count);

                    for (int i = 0; i < count; i++)
                    {
                        counter++;
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                    }

                    continue;
                }

                queue.Enqueue(input);
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
