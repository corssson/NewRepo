using System;

namespace task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение x: ");
            double x = double.Parse(Console.ReadLine());

            double y = F(x);

            Console.WriteLine($"f({x}) = {y:F4}");
        }

        static double F(double x)
        {
            double numerator = Math.Pow(x, 2) + 10;
            double denominator = Math.Sqrt(Math.Pow(x, 2) + 1); 

            return numerator / denominator;
        }
    }
}
