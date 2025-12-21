using System;

namespace Task12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m = 0, n = 0;

            while (true)
            {
                Console.WriteLine("Введите через пробел два натуральных числа m и n от 5 до 20");
                Console.WriteLine("(Enter - отказ от ввода)");
                var input = Console.ReadLine();

                if (input == string.Empty)
                    return;

                var parts = input.Split();

                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out m) &&
                    int.TryParse(parts[1], out n) &&
                    5 <= m && m <= 20 &&
                    5 <= n && n <= 20)
                    break;

                Console.WriteLine("Ошибка ввода");
            }

            var matrix = new int[m, n];
            var rnd = new Random();

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = rnd.Next(0, 100);

            Console.WriteLine("\nИсходный массив:");
            PrintTable(matrix);
            Console.WriteLine();

            if (TryFindZero(matrix, out int row, out int col))
                Console.WriteLine($"В массиве есть элемент 0 (строка {row}, столбец {col})");
            else
                Console.WriteLine("В массиве нет элементов, равных 0");

            Console.WriteLine();

            int[] differences = GetEvenOddDifferences(matrix);

            for (int i = 0; i < differences.Length; i++)
                Console.WriteLine($"Строка {i}: сумма чётных - сумма нечётных = {differences[i]}");
        }

        static void PrintTable(int[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                    Console.Write($"{table[i, j],3} ");
                Console.WriteLine();
            }
        }

        static bool TryFindZero(int[,] table, out int rowIndex, out int colIndex)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j] == 0)
                    {
                        rowIndex = i;
                        colIndex = j;
                        return true;
                    }
                }
            }

            rowIndex = -1;
            colIndex = -1;
            return false;
        }

        static int[] GetEvenOddDifferences(int[,] table)
        {
            int rows = table.GetLength(0);
            int cols = table.GetLength(1);
            int[] result = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int evenSum = 0;
                int oddSum = 0;

                for (int j = 0; j < cols; j++)
                {
                    int value = table[i, j];

                    if (value % 2 == 0)
                        evenSum += value;
                    else
                        oddSum += value;
                }

                result[i] = evenSum - oddSum;
            }

            return result;
        }
    }
}
