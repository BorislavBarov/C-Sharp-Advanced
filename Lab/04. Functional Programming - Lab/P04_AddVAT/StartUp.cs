namespace P04_AddVAT
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var prices = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(p => p * 1.2)
                .ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
