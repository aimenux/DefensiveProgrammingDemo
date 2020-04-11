using System;
using System.Collections.Generic;
using Sharprompt;
using static CodeContractsFullApp.Examples;

namespace CodeContractsFullApp
{
    public static class Program
    {
        public static void Main()
        {
            var options = new Dictionary<string, Action>
            {
                [nameof(EnsuresViolationExample1)] = EnsuresViolationExample1,
                [nameof(EnsuresViolationExample2)] = EnsuresViolationExample2,
                [nameof(RequiresViolationExample1)] = RequiresViolationExample1,
                [nameof(RequiresViolationExample2)] = RequiresViolationExample2,
                [nameof(InvariantViolationExample1)] = InvariantViolationExample1,
                [nameof(InvariantViolationExample2)] = InvariantViolationExample2,
            };
            var choice = Prompt.Select("Select a violation example", options.Keys);
            options[choice].Invoke();
            Console.WriteLine("Press any key to exit !");
            Console.ReadKey();
        }
    }
}
