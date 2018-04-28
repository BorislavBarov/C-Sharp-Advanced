namespace P03_CustomMinFunction
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Func<int[], int> func = x => x.Min();

            var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(func(numbers));
        }
    }
}
