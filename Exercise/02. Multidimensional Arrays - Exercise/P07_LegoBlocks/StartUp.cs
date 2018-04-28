namespace P07_LegoBlocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var leftJaggedArray = new int[n][];
            var rightJaggedArray = new int[n][];

            for (int row = 0; row < leftJaggedArray.Length; row++)
            {
                leftJaggedArray[row] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < rightJaggedArray.Length; row++)
            {
                rightJaggedArray[row] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Reverse()
                    .ToArray();
            }

            var finalMatrix = new int[n][];

            for (int row = 0; row < n; row++)
            {
                var currentArray = new int[leftJaggedArray[row].Length + rightJaggedArray[row].Length];
                leftJaggedArray[row].CopyTo(currentArray, 0);
                rightJaggedArray[row].CopyTo(currentArray, leftJaggedArray[row].Length);

                finalMatrix[row] = currentArray;
            }

            var totalCount = 0;
            var length = new HashSet<int>();

            for (int row = 0; row < finalMatrix.Length; row++)
            {
                totalCount += finalMatrix[row].Length;
                length.Add(finalMatrix[row].Length);
            }

            if (length.Count == 1)
            {
                for (int row = 0; row < finalMatrix.Length; row++)
                {
                    Console.WriteLine($"[{string.Join(", ", finalMatrix[row])}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {totalCount}");
            }
        }
    }
}
