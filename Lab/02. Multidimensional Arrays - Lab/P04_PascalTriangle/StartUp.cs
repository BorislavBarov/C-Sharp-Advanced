namespace P04_PascalTriangle
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var jaggedArray = new long[n][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = new long[row + 1];
                jaggedArray[row][0] = 1;
                jaggedArray[row][jaggedArray[row].Length - 1] = 1;

                for (int col = 1; col < jaggedArray[row].Length - 1; col++)
                {
                    jaggedArray[row][col] = jaggedArray[row - 1][col - 1] + jaggedArray[row - 1][col];
                }
            }

            foreach (var array in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", array));
            }
        }
    }
}
