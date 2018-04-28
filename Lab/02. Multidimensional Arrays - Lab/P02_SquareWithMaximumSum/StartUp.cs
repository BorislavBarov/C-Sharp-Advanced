namespace P02_SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            
            var inputRows = input[0];
            var inputCols = input[1];

            var matrix = new int[inputRows, inputCols];

            for (int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
            {
                var line = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

                for (int currentCol = 0; currentCol < matrix.GetLength(1); currentCol++)
                {
                    var currentElement = line[currentCol];

                    matrix[currentRow, currentCol] = currentElement;
                }
            }

            var bestSum = int.MinValue;
            var indexRow = -1;
            var indexCol = -1;

            for (int currentRow = 0; currentRow < matrix.GetLength(0) - 1; currentRow++)
            {
                for (int currentCol = 0; currentCol < matrix.GetLength(1) - 1; currentCol++)
                {
                    var currentSum = matrix[currentRow, currentCol] + 
                                     matrix[currentRow, currentCol + 1] + 
                                     matrix[currentRow + 1, currentCol] + 
                                     matrix[currentRow + 1, currentCol + 1];

                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                        indexRow = currentRow;
                        indexCol = currentCol;
                    }
                }
            }

            Console.WriteLine($"{matrix[indexRow, indexCol]} {matrix[indexRow, indexCol + 1]}");
            Console.WriteLine($"{matrix[indexRow + 1, indexCol]} {matrix[indexRow + 1, indexCol + 1]}");
            Console.WriteLine(bestSum);
        }
    }
}
