namespace P12_InfernoIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select((number, index) => new { Number = int.Parse(number), Index = index })
                .ToDictionary(element => element.Index, element => element.Number);

            var command = Console.ReadLine();

            var activeFilters = new Dictionary<string, int[]>();

            while (command != "Forge")
            {
                var parameters = command.Split(';');

                var action = parameters[0];
                var filter = parameters[1].GetHashCode();
                var filterCondition = int.Parse(parameters[2]);

                var filterName = string.Empty + filter + filterCondition;

                switch (action)
                {
                    case "Exclude":
                        if (!activeFilters.ContainsKey(filterName))
                        {
                            activeFilters.Add(filterName, new[] { filter, filterCondition });
                        }

                        break;

                    case "Reverse":
                        if (activeFilters.ContainsKey(filterName))
                        {
                            activeFilters.Remove(filterName);
                        }

                        break;
                }

                command = Console.ReadLine();
            }

            Func<List<int>, int, bool> validator = (list, sum) => !list.Sum().Equals(sum);

            var sumLeft = "Sum Left".GetHashCode();
            var sumRight = "Sum Right".GetHashCode();
            var sumLeftRight = "Sum Left Right".GetHashCode();

            var filteredNumbers = new List<int>();

            foreach (var numberWithPosition in numbers)
            {
                var currentNumberIndex = numberWithPosition.Key;
                var dreddApproved = true;

                foreach (var activeFilter in activeFilters.Values)
                {
                    var left = 0;
                    var num = numbers[currentNumberIndex];
                    var right = 0;

                    if (activeFilter[0].Equals(sumLeft))
                    {
                        numbers.TryGetValue(currentNumberIndex - 1, out left);
                    }
                    else if (activeFilter[0].Equals(sumRight))
                    {
                        numbers.TryGetValue(currentNumberIndex + 1, out right);
                    }
                    else if (activeFilter[0].Equals(sumLeftRight))
                    {
                        numbers.TryGetValue(currentNumberIndex - 1, out left);
                        numbers.TryGetValue(currentNumberIndex + 1, out right);
                    }

                    var selectedNumbers = new List<int> { left, num, right };
                    dreddApproved = validator(selectedNumbers, activeFilter[1]);

                    if (!dreddApproved)
                    {
                        break;
                    }
                }

                if (dreddApproved)
                {
                    filteredNumbers.Add(numberWithPosition.Value);
                }
            }

            Console.WriteLine(string.Join(" ", filteredNumbers));
        }
    }
}
