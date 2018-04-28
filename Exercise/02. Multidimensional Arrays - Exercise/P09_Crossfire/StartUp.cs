namespace P09_Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = matrixSizes[0];
            var cols = matrixSizes[1];

            var fakeMatrix = new List<List<int>>();
            var counter = 0;

            for (int row = 0; row < rows; row++)
            {
                var innerList = new List<int>();

                for (int col = 0; col < cols; col++)
                {
                    counter++;
                    innerList.Add(counter);
                }

                fakeMatrix.Add(innerList);
            }

            string command;

            while ((command = Console.ReadLine()) != "Nuke it from orbit")
            {
                var commandArgs = command
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var shotRow = commandArgs[0];
                var shotCol = commandArgs[1];
                var radius = commandArgs[2];

                for (int row = 0; row < fakeMatrix.Count; row++)
                {
                    for (int col = 0; col < fakeMatrix[row].Count; col++)
                    {
                        if ((row == shotRow && Math.Abs(col - shotCol) <= radius) ||
                            (col == shotCol && Math.Abs(row - shotRow) <= radius))
                        {
                            fakeMatrix[row][col] = 0;
                        }
                    }
                }

                for (int row = 0; row < fakeMatrix.Count; row++)
                {
                    fakeMatrix[row].RemoveAll(x => x == 0);

                    if (fakeMatrix[row].Count == 0)
                    {
                        fakeMatrix.RemoveAt(row);
                        row--;
                    }
                }
            }

            for (int row = 0; row < fakeMatrix.Count; row++)
            {
                Console.WriteLine(string.Join(" ", fakeMatrix[row]));
            }
        }
    }
}
