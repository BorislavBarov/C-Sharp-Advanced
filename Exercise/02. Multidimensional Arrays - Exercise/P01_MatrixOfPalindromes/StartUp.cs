namespace P01_MatrixOfPalindromes
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var inputRows = input[0];
            var inputCols = input[1];
            var matrix = new string[inputRows, inputCols];

            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
            {
                for (int currentCol = 0; currentCol < matrix.GetLength(1); currentCol++)
                {
                    var currentString = alphabet[currentRow].ToString() + alphabet[currentCol + currentRow] + alphabet[currentRow];
                    matrix[currentRow, currentCol] = currentString + " ";
                }
            }

            for (int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
            {
                for (int currentCol = 0; currentCol < matrix.GetLength(1); currentCol++)
                {
                    Console.Write(matrix[currentRow, currentCol]);
                }

                Console.WriteLine();
            }
        }
    }
}
