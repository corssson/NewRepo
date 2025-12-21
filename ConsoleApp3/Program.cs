using System;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число n (100 <= n <= 999)");
            int n = int.Parse(Console.ReadLine());

            int a = n / 100;          
            int c = (n / 10) % 10;    
            int b = n % 10;           

            int x = 100 * a + 10 * b + c;

            Console.WriteLine("Искомое число x: " + x);
        }
    }
}
