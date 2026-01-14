using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        const int min = 10;
        const int max = 1_000_000_000;

        for (int n = 4; n <= 7; n++)
        {
            List<long> found = new List<long>();
            long sumOfAll = 0;

            Console.WriteLine($"\n=== n = {n} ===");

            for (long i = min; i < max; i++)
            {
                if (IsEqualToSumOfPowers(i, n))
                {
                    found.Add(i);
                    sumOfAll += i;
                    Console.WriteLine($"Найдено число: {i}");
                }
            }

            Console.WriteLine($"Всего найдено чисел: {found.Count}");
            Console.WriteLine($"Сумма всех чисел: {sumOfAll}");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }

    static bool IsEqualToSumOfPowers(long number, int n)
    {
        long abc = number;
        long sum = 0;

        while (abc > 0)
        {
            int digit = (int)(abc % 10);
            sum += PowInt(digit, n);
            abc /= 10;

            if (sum > number)
                return false;
        }

        return sum == number;
    }


    static long PowInt(int baseValue, int n)
    {
        long result = 1;
        for (int i = 0; i < n; i++)
            result *= baseValue;
        return result;
    }
}
