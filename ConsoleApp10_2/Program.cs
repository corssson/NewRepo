using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите число a (1 < a < 2): ");
        double a = double.Parse(Console.ReadLine());

        int n = 1;
        while (true)
        {
            double value = 1.0 + 1.0 / n;

            if (value < a)
                break;

            n++;
        }

        Console.WriteLine($"Первое число последовательности меньше a: 1 + 1/{n}");
    }
}
