namespace P07_PredicateForNames
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Func<string, bool> func = x => x.Length <= n;

            Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(func)
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
