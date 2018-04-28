namespace P06_TruckTour
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var startPump = 0;
            var tank = 0;

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var amount = line[0];
                var distance = line[1];

                tank += amount;

                if (tank >= distance)
                {
                    tank -= distance;
                }
                else
                {
                    startPump = i + 1;
                    tank = 0;
                }
            }

            Console.WriteLine(startPump);
        }
    }
}
