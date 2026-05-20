using System;
using System.Globalization;

namespace ComplexNumberStruct
{
    public struct ComplexNumber
    {
        private const double Epsilon = 1e-13;

        private double re;
        private double im;

        public double Re
        {
            get => re;
            set => re = value;
        }

        public double Im
        {
            get => im;
            set => im = value;
        }

        public double Abs
        {
            get => Math.Sqrt(re * re + im * im);
        }

        public ComplexNumber(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public override string ToString()
        {
            if (Math.Abs(re) < Epsilon && Math.Abs(im) < Epsilon)
                return "0";

            if (Math.Abs(re) < Epsilon)
            {
                if (Math.Abs(im - 1) < Epsilon)
                    return "i";
                if (Math.Abs(im + 1) < Epsilon)
                    return "-i";
                return im.ToString(CultureInfo.InvariantCulture) + "i";
            }

            if (Math.Abs(im) < Epsilon)
                return re.ToString(CultureInfo.InvariantCulture);

            string sign = im >= 0 ? "+" : "-";
            double absIm = Math.Abs(im);
            string reStr = re.ToString(CultureInfo.InvariantCulture);
            string imStr = absIm.ToString(CultureInfo.InvariantCulture);

            if (Math.Abs(absIm - 1) < Epsilon)
                return reStr + " " + sign + " i";

            return reStr + " " + sign + " " + imStr + "i";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ComplexNumber))
                return false;

            ComplexNumber other = (ComplexNumber)obj;

            return Math.Abs(re - other.re) < Epsilon &&
                   Math.Abs(im - other.im) < Epsilon;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + re.GetHashCode();
                hash = hash * 23 + im.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(ComplexNumber left, ComplexNumber right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ComplexNumber left, ComplexNumber right)
        {
            return !left.Equals(right);
        }

        public static ComplexNumber operator +(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(left.re + right.re, left.im + right.im);
        }

        public static ComplexNumber operator -(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(left.re - right.re, left.im - right.im);
        }

        public static ComplexNumber operator -(ComplexNumber value)
        {
            return new ComplexNumber(-value.re, -value.im);
        }
    }
}