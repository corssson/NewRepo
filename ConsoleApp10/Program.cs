using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите курс доллара (руб за 1$): ");
        double rate = double.Parse(Console.ReadLine());

        Console.WriteLine("Доллары\tРубли");

        for (int dollars = 10; dollars <= 1000; dollars += 10)
        {
            double rubles = dollars * rate;
            Console.WriteLine($"{dollars}\t{rubles:F2}");
        }
    }
}
