namespace P05_FilterByAge
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                var personName = line[0];
                var personAge = int.Parse(line[1]);

                people.Add(personName, personAge);
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            var filter = CreateFilter(age, condition);
            var printer = CreatePrinter(format);

            foreach (var person in people)
            {
                if (filter(person.Value))
                {
                    printer(person);
                }
            }
        }

        public static Func<int, bool> CreateFilter(int age, string condition)
        {
            switch (condition)
            {
                case "younger":
                    return x => x < age;
                case "older":
                    return x => x >= age;
                default:
                    return null;
            }
        }

        public static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                case "name":
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                default:
                    return null;
            }
        }
    }
}
