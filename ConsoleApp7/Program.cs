using System;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число k");
            var k = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите целое число m");
            var m = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите целое число n");
            var n = int.Parse(Console.ReadLine());

            if (IfLogicalExpressionTrue(k, m, n))
                Console.WriteLine("Ровно одно из чисел k, m или n кратно 11");
            else
                Console.WriteLine("Условие не выполняется");
        }

        static bool IfLogicalExpressionTrue(int k, int m, int n)
        {
            bool k11 = k % 11 == 0;
            bool m11 = m % 11 == 0;
            bool n11 = n % 11 == 0;

            int count = 0;
            if (k11) count++;
            if (m11) count++;
            if (n11) count++;

            return count == 1;
        }
    }
}
