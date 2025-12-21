using System;

namespace Task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число элементов массива n");
            int n = int.Parse(Console.ReadLine());

            if (n < 1)
            {
                Console.WriteLine("Слишком маленький массив.");
                return;
            }

            double[] numbers = CreateRandomArray(n, -10.0, 10.0);

            Console.WriteLine("Исходный массив:");
            PrintDoubleArray(numbers);

            MakeEvenElementsAbs(numbers);
            Console.WriteLine("После замены чётных элементов их модулем:");
            PrintDoubleArray(numbers);

            double sqrtFromSumSquares = GetSqrtFromSumOfSquares(numbers);
            Console.WriteLine($"Квадратный корень из суммы квадратов элементов: {sqrtFromSumSquares:F3}\n");

            Console.WriteLine("Введите целое число k для функции sin(kx):");
            int k = int.Parse(Console.ReadLine());

            double[] sinArray = GetSinKxArray(numbers, k);
            Console.WriteLine("Массив значений sin(kx):");
            PrintDoubleArray(sinArray);
        }

        static double[] CreateRandomArray(int n, double min, double max)
        {
            var rnd = new Random();
            var array = new double[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = min + rnd.NextDouble() * (max - min);
            }

            return array;
        }

        static void PrintDoubleArray(double[] array)
        {
            foreach (var x in array)
                Console.Write($"{x:F3} ");

            Console.WriteLine();
        }

        static void MakeEvenElementsAbs(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                    array[i] = Math.Abs(array[i]);
            }
        }


        static double GetSqrtFromSumOfSquares(double[] array)
        {
            double sum = 0;

            foreach (var x in array)
                sum += x * x;

            return Math.Sqrt(sum);
        }

        static double[] GetSinKxArray(double[] array, int k)
        {
            double[] result = new double[array.Length];

            for (int i = 0; i < array.Length; i++)
                result[i] = Math.Sin(k * array[i]);

            return result;
        }
    }
}
