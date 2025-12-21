using System;

namespace TriangleTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты вершин треугольника:");

            Console.Write("x1 y1: ");
            var p1 = Console.ReadLine().Split();
            double x1 = double.Parse(p1[0]);
            double y1 = double.Parse(p1[1]);

            Console.Write("x2 y2: ");
            var p2 = Console.ReadLine().Split();
            double x2 = double.Parse(p2[0]);
            double y2 = double.Parse(p2[1]);

            Console.Write("x3 y3: ");
            var p3 = Console.ReadLine().Split();
            double x3 = double.Parse(p3[0]);
            double y3 = double.Parse(p3[1]);

            double a = Distance(x1, y1, x2, y2);
            double b = Distance(x2, y2, x3, y3);
            double c = Distance(x3, y3, x1, y1);

            double perimeter = a + b + c;

            double area = 0.5 * Math.Abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));

            Console.WriteLine($"Периметр треугольника: {perimeter:F3}");
            Console.WriteLine($"Площадь треугольника:  {area:F3}");
        }

        static double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
