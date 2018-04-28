namespace P06_TargetPractice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var sizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = sizes[0];
            var cols = sizes[1];
            var matrix = new char[rows, cols];

            var inputString = Console.ReadLine();
            var queue = new Queue<char>(inputString);

            var shotParameters = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var impactRow = shotParameters[0];
            var impactCol = shotParameters[1];
            var radius = shotParameters[2];
            
            FillMatrix(matrix, queue);

            FireAShot(matrix, impactRow, impactCol, radius);

            RunGravity(matrix);

            PrintMatrix(matrix);
        }

        private static void FillMatrix(char[,] matrix, Queue<char> queue)
        {
            int numberOfRows = 0;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (numberOfRows % 2 != 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        var currentLetter = queue.Dequeue();
                        matrix[row, col] = currentLetter;
                        queue.Enqueue(currentLetter);
                    }
                }
                else if (numberOfRows % 2 == 0)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        var currentLetter = queue.Dequeue();
                        matrix[row, col] = currentLetter;
                        queue.Enqueue(currentLetter);
                    }
                }

                numberOfRows++;
            }
        }

        private static void FireAShot(char[,] matrix, int impactRow, int impactCol, int radius)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (((row - impactRow) * (row - impactRow)) + ((col - impactCol) * (col - impactCol)) <= radius * radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static void RunGravity(char[,] matrix)
        {
            while (true)
            {
                var isFallen = false;

                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == ' ' && matrix[row - 1, col] != ' ')
                        {
                            matrix[row, col] = matrix[row - 1, col];
                            matrix[row - 1, col] = ' ';
                            isFallen = true;
                        }
                    }
                }

                if (!isFallen)
                {
                    break;
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            var sb = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append(matrix[row, col]);
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
