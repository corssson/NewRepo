using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите натуральное число n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введите число k (1 <= k <= 8): ");
        int k = int.Parse(Console.ReadLine());

        int product = 1;
        bool hasDigits = false;

        int temp = n;
        while (temp > 0)
        {
            int digit = temp % 10;  
            if (digit > k)
            {
                product *= digit;
                hasDigits = true;
            }
            temp /= 10;          
        }

        if (!hasDigits)
            product = 1;

        Console.WriteLine($"Произведение цифр числа {n}, больших {k}, равно {product}");
    }
}
