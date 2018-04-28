namespace P05_SequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var number = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            var result = new List<long>();

            queue.Enqueue(number);
            result.Add(number);

            while (result.Count < 50)
            {
                var firstCalc = queue.Peek() + 1;
                queue.Enqueue(firstCalc);
                result.Add(firstCalc);

                if (result.Count < 50)
                {
                    var secondCalc = 2 * queue.Peek() + 1;
                    queue.Enqueue(secondCalc);
                    result.Add(secondCalc);
                }

                if (result.Count < 50)
                {
                    var thirdCalc = queue.Peek() + 2;
                    queue.Enqueue(thirdCalc);
                    result.Add(thirdCalc);
                }

                queue.Dequeue();
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
