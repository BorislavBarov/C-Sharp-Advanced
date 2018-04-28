namespace P01_ActionPrint
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Action<string> action = x => Console.WriteLine(x);

            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var name in names)
            {
                action(name);
            }
        }
    }
}
