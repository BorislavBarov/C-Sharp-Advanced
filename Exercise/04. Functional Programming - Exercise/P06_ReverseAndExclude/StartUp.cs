namespace P06_ReverseAndExclude
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                   .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

            var n = int.Parse(Console.ReadLine());

            Func<int, bool> func = x => x % n != 0;

            numbers = numbers.Where(func).Reverse().ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
