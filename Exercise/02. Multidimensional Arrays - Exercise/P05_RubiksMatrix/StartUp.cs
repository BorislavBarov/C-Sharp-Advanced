namespace P05_RubiksMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = input[0];
            var cols = input[1];
            var matrix = new int[rows, cols];

            var counter = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = counter;
                    counter++;
                }
            }

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var rowOrCol = int.Parse(command[0]);
                var direction = command[1];
                var moves = int.Parse(command[2]);
                var arrayOfRows = new int[rows];
                var arrayOfCols = new int[cols];

                switch (direction)
                {
                    case "up":
                        var queueUp = new Queue<int>();

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            queueUp.Enqueue(matrix[row, rowOrCol]);
                        }

                        for (int row = 0; row < moves % matrix.GetLength(0); row++)
                        {
                            queueUp.Enqueue(queueUp.Dequeue());
                        }

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            matrix[row, rowOrCol] = queueUp.Dequeue();
                        }

                        break;

                    case "down":
                        var queueDown = new Queue<int>();

                        for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                        {
                            queueDown.Enqueue(matrix[row, rowOrCol]);
                        }

                        for (int row = 0; row < moves % matrix.GetLength(0); row++)
                        {
                            queueDown.Enqueue(queueDown.Dequeue());
                        }

                        for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                        {
                            matrix[row, rowOrCol] = queueDown.Dequeue();
                        }

                        break;

                    case "left":
                        var queueLeft = new Queue<int>();

                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            queueLeft.Enqueue(matrix[rowOrCol, col]);
                        }

                        for (int col = 0; col < moves % matrix.GetLength(1); col++)
                        {
                            queueLeft.Enqueue(queueLeft.Dequeue());
                        }

                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            matrix[rowOrCol, col] = queueLeft.Dequeue();
                        }

                        break;

                    case "right":
                        var queueRight = new Queue<int>();

                        for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                        {
                            queueRight.Enqueue(matrix[rowOrCol, col]);
                        }

                        for (int col = 0; col < moves % matrix.GetLength(1); col++)
                        {
                            queueRight.Enqueue(queueRight.Dequeue());
                        }

                        for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                        {
                            matrix[rowOrCol, col] = queueRight.Dequeue();
                        }

                        break;
                }                              
            }

            counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    counter++;

                    if (matrix[row, col] != counter)
                    {
                        for (int innerRow = 0; innerRow < matrix.GetLength(0); innerRow++)
                        {
                            var isBreak = false;

                            for (int innerCol = 0; innerCol < matrix.GetLength(1); innerCol++)
                            {
                                if (matrix[innerRow, innerCol] == counter)
                                {
                                    var temp = matrix[row, col];
                                    matrix[row, col] = counter;
                                    matrix[innerRow, innerCol] = temp;

                                    Console.WriteLine($"Swap ({row}, {col}) with ({innerRow}, {innerCol})");
                                    isBreak = true;
                                    break;
                                }
                            }

                            if (isBreak == true)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                }
            }
        }
    }
}
