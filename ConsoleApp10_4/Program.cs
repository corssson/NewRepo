using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите натуральное число n (> 1000): ");
        int n = int.Parse(Console.ReadLine());

        int resultReversed = 0; 

        int temp = n;
        while (temp > 0)
        {
            int digit = temp % 10;

            if (digit % 2 == 1)
            {
                resultReversed = resultReversed * 10 + digit;
            }

            temp /= 10;       
        }

        int result = 0;
        while (resultReversed > 0)
        {
            int digit = resultReversed % 10;
            result = result * 10 + digit;
            resultReversed /= 10;
        }

        Console.WriteLine($"Число после удаления чётных цифр: {result}");
    }
}
