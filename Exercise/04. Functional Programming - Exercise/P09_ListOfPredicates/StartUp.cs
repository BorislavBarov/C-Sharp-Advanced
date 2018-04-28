namespace P09_ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Func<int, int, bool> filter = (x, y) => x % y == 0;

            var result = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                var hasPassed = true;

                foreach (var divider in dividers)
                {
                    if (!filter(i, divider))
                    {
                        hasPassed = false;
                        break;
                    }
                }

                if (hasPassed)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
