namespace P12_StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var command = Console.ReadLine().Split(new string[] { "Rotate(", ")" }, StringSplitOptions.RemoveEmptyEntries);
            var degrees = int.Parse(command[0]);

            var tempList = new List<string>();

            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                tempList.Add(line);
            }

            var rows = tempList.Count();
            var cols = tempList.Max(x => x.Length);

            var originalMatrix = new char[rows, cols];

            for (int row = 0; row < originalMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < originalMatrix.GetLength(1); col++)
                {
                    if (tempList[row].Length > col)
                    {
                        originalMatrix[row, col] = tempList[row][col];
                    }
                    else
                    {
                        originalMatrix[row, col] = ' ';
                    }
                }
            }

            var count = (degrees / 90) % 4;
            var firstMatrix = new char[cols, rows];
            var secondMatrix = new char[rows, cols];
            var thirdMatrix = new char[cols, rows];

            if (count == 0)
            {
                for (int row = 0; row < originalMatrix.GetLength(0); row++)
                {
                    for (int col = 0; col < originalMatrix.GetLength(1); col++)
                    {
                        Console.Write(originalMatrix[row, col]);
                    }

                    Console.WriteLine();
                }

                Environment.Exit(0);
            }

            for (int col = 0; col < originalMatrix.GetLength(1); col++)
            {
                for (int row = originalMatrix.GetLength(0) - 1; row >= 0; row--)
                {
                    firstMatrix[col, row] = originalMatrix[row, col];
                }
            }

            for (int col = firstMatrix.GetLength(1) - 1; col >= 0; col--)
            {
                for (int row = firstMatrix.GetLength(0) - 1; row >= 0; row--)
                {
                    secondMatrix[col, row] = firstMatrix[row, col];
                }
            }

            for (int col = secondMatrix.GetLength(1) - 1; col >= 0; col--)
            {
                for (int row = 0; row < secondMatrix.GetLength(0); row++)
                {
                    thirdMatrix[col, row] = secondMatrix[row, col];
                }
            }

            if (count == 1)
            {
                for (int col = 0; col < originalMatrix.GetLength(1); col++)
                {
                    for (int row = originalMatrix.GetLength(0) - 1; row >= 0; row--)
                    {
                        firstMatrix[col, row] = originalMatrix[row, col];

                        Console.Write(firstMatrix[col, row]);
                    }

                    Console.WriteLine();
                }
            }
            else if (count == 2)
            {
                for (int col = firstMatrix.GetLength(1) - 1; col >= 0; col--)
                {
                    for (int row = firstMatrix.GetLength(0) - 1; row >= 0; row--)
                    {
                        secondMatrix[col, row] = firstMatrix[row, col];

                        Console.Write(secondMatrix[col, row]);
                    }

                    Console.WriteLine();
                }
            }
            else if (count == 3)
            {
                for (int col = secondMatrix.GetLength(1) - 1; col >= 0; col--)
                {
                    for (int row = 0; row < secondMatrix.GetLength(0); row++)
                    {
                        thirdMatrix[col, row] = secondMatrix[row, col];

                        Console.Write(thirdMatrix[col, row]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
