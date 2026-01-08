using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите a (натуральное число): ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите b (натуральное число, b > a): ");
        int b = int.Parse(Console.ReadLine());

        long totalSum = 0;

        for (int n = a; n <= b; n++)
        {
            for (int d = 1; d <= n; d++)
            {
                if (n % d == 0)
                    totalSum += d;
            }
        }

        Console.WriteLine($"Сумма всех делителей чисел от {a} до {b} равна {totalSum}");
    }
}
