namespace P01_SumMatrixElements
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var inputRow = input[0];
            var inputCol = input[1];

            var matrix = new int[inputRow, inputCol];
            var sum = int.MinValue;

            for (int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
            {
                var line = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int currentCol = 0; currentCol < matrix.GetLength(1); currentCol++)
                {
                    var currentElement = line[currentCol];

                    matrix[currentRow, currentCol] = currentElement;
                    sum += currentElement;
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
