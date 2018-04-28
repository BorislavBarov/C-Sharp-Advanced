namespace P04_FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var lowerBound = input[0];
            var upperBound = input[1];

            var command = Console.ReadLine();
            
            var numbers = new List<int>();

            for (int counter = lowerBound; counter <= upperBound; counter++)
            {
                numbers.Add(counter);
            }

            var filter = Filter(command);
            var result = numbers.Where(x => filter.Invoke(x)).ToList();

            Console.WriteLine(string.Join(" ", result));
        }

        public static Predicate<int> Filter (string command)
        {
            if (command == "even")
            {
                return x => x % 2 == 0;
            }
            else
            {
                return x => x % 2 != 0;
            }
        }
    }
}
