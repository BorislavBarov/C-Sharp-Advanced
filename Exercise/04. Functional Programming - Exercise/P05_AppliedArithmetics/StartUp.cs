namespace P05_AppliedArithmetics
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

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                var printer = Printer();

                if (command != "print")
                {
                    numbers = numbers.Select(ChangeNumber(command)).ToArray();
                }
                else if (command == "print")
                {
                    printer(numbers);
                }
            }
        }

        public static Func<int, int> ChangeNumber(string command)
        {
            switch (command)
            {
                case "add":
                    return x => x + 1;
                case "multiply":
                    return x => x * 2;
                case "subtract":
                    return x => x - 1;
                default:
                    return null;
            }
        }

        public static Action<int[]> Printer()
        {
            return x => Console.WriteLine(string.Join(" ", x));
        }
    }
}
