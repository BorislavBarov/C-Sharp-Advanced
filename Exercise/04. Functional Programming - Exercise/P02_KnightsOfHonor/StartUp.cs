namespace P02_KnightsOfHonor
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Action<string> action = x => Console.WriteLine($"Sir {x}");

            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                action(name);
            }
        }
    }
}
