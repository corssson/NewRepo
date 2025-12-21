using System;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = Part(2, 3, 5) + Part(5, 7, 12) + Part(11, 13, 24);

            Console.WriteLine(Math.Round(x, 3));
        }

        static double Part(double aDeg, double bDeg, double c)
        {
            double aRad = aDeg * Math.PI / 180.0;
            double bRad = bDeg * Math.PI / 180.0;

            return (Math.Sin(aRad) + Math.Sin(bRad)) / c;
        }
    }
}
