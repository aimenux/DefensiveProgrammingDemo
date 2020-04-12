using System;
using System.Collections.Generic;
using static CodeContractsFullApp.Examples;

namespace CodeContractsFullApp
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
                    [1] = EnsuresViolationExample1,
                    [2] = EnsuresViolationExample2,
                    [3] = RequiresViolationExample1,
                    [4] = RequiresViolationExample2,
                    [5] = InvariantViolationExample1,
                    [6] = InvariantViolationExample2,
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
                ConsoleColor.Green.WriteLine($"1. Run {nameof(EnsuresViolationExample1)}");
                ConsoleColor.Green.WriteLine($"2. Run {nameof(EnsuresViolationExample2)}");
                ConsoleColor.Green.WriteLine($"3. Run {nameof(RequiresViolationExample1)}");
                ConsoleColor.Green.WriteLine($"4. Run {nameof(RequiresViolationExample2)}");
                ConsoleColor.Green.WriteLine($"5. Run {nameof(InvariantViolationExample1)}");
                ConsoleColor.Green.WriteLine($"6. Run {nameof(InvariantViolationExample2)}");
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
