using System;

namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение аргумента");

            var x = double.Parse(Console.ReadLine());

            Console.WriteLine($"f({x:F2}) = {F(x):F2}");
        }

        static double F(double x)
        {
            if (x > 2)
                return 2;
            else if (x >= -2)
                return x;
            else
                return -2;
        }
    }
}
