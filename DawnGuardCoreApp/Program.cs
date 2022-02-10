using System;
using System.Collections.Generic;
using static DawnGuardCoreApp.Examples;

namespace DawnGuardCoreApp
{
    public static class Program
    {
        public static void Main()
        {
            while (true)
            {
                var choice = GetChoice();

                var options = new Dictionary<int, Action>
                {
                    [1] = ViolationExample1,
                    [2] = ViolationExample2,
                    [3] = ViolationExample3,
                    [4] = ViolationExample4,
                    [5] = ViolationExample5,
                    [6] = ViolationExample6,
                    [7] = () => {},
                };

                try
                {
                    options[choice].Invoke();
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteLine($"{ex}\n");
                }

                if (choice == 7)
                {
                    break;
                }
            }
        }

        private static int GetChoice()
        {
            int choice;

            do
            {
                ConsoleColor.Green.WriteLine($"1. Run {nameof(ViolationExample1)}");
                ConsoleColor.Green.WriteLine($"2. Run {nameof(ViolationExample2)}");
                ConsoleColor.Green.WriteLine($"3. Run {nameof(ViolationExample3)}");
                ConsoleColor.Green.WriteLine($"4. Run {nameof(ViolationExample4)}");
                ConsoleColor.Green.WriteLine($"5. Run {nameof(ViolationExample5)}");
                ConsoleColor.Green.WriteLine($"6. Run {nameof(ViolationExample6)}");
                ConsoleColor.Green.WriteLine($"7. Exit {typeof(Program).Namespace}");
                Console.WriteLine();
                ConsoleColor.Yellow.WriteLine("Please enter a choice ?");
                choice = ReadChoice();
            }
            while (choice < 1 || choice > 7);

            return choice;
        }

        private static int ReadChoice()
        {
            ConsoleColor.Cyan.SetColor();
            var input = Console.ReadLine();
            Console.WriteLine();
            if (int.TryParse(input, out var choice))
            {
                return choice;
            }

            return -1;
        }
    }
}
