using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите число административных единиц n: ");
        int n = int.Parse(Console.ReadLine());

        double totalArea = 0;

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Административная единица {i}:");

            Console.Write("  Число жителей (в тыс. чел.): ");
            double population = double.Parse(Console.ReadLine());

            Console.Write("  Плотность населения (в тыс. чел./км^2): ");
            double density = double.Parse(Console.ReadLine());

            double area = population / density;
            totalArea += area;
        }

        Console.WriteLine($"Площадь страны = {totalArea:F2} км^2");
    }
}
