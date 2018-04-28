namespace P03_CountUppercaseWords
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Func<string, bool> func = x => char.IsUpper(x[0]);

            var letters = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(func)
                .ToList();

            foreach (var letter in letters)
            {
                Console.WriteLine(letter);
            }
        }
    }
}
