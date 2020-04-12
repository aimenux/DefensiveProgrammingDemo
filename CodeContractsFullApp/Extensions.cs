using System;

namespace CodeContractsFullApp
{
    public static class Extensions
    {
        public static void WriteLine(this ConsoleColor color, object value)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        public static void SetColor(this ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
