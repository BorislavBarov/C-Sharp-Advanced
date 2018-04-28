namespace P03_GroupNumbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var sizes = new int[3];

            foreach (var number in numbers)
            {
                sizes[Math.Abs(number % 3)]++;
            }

            var jaggedArray = new int[3][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = new int[sizes[i]];
            }

            var index = new int[3];

            foreach (var number in numbers)
            {
                var remainder = Math.Abs(number % 3);
                jaggedArray[remainder][index[remainder]] = number;
                index[remainder]++;
            }

            foreach (var array in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", array));
            }
        }
    }
}
