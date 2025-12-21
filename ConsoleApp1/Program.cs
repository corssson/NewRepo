using System;

namespace ColoredPoem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Александр Пушкин");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("«Я помню чудное мгновенье…»\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Я помню чудное мгновенье:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Передо мной явилась ты,");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Как мимолётное виденье,");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Как гений чистой красоты.");

            Console.ResetColor();
        }
    }
}
