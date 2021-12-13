using System;
using System.Reflection.Metadata;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// 
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public Complex(double realPart, double imaginaryPart)
        {
            this.Real = realPart;
            this.Imaginary = imaginaryPart;
        }

        public double Real { get; }
        
        public double Imaginary { get; }

        public double Modulus => Math.Sqrt(Math.Pow(2, Real) + Math.Pow(2, Imaginary));
        
        public double Phase => Math.Atan2(Imaginary, Real);

        public Complex Complement() => new Complex(Real, -Imaginary);

        public Complex Plus(Complex complexToSum) => new Complex(Real + complexToSum.Real,
            Imaginary + complexToSum.Imaginary);
        
        public Complex Minus(Complex complexToSum) => new Complex(Real - complexToSum.Real,
            Imaginary + complexToSum.Imaginary);

        public override string ToString()
        {
            var sign = Imaginary > 0 ? "+" : "-";
            return $"{Real} {sign} i{Math.Abs(Imaginary)}";
        }

        protected bool Equals(Complex other)
        {
            return Real.Equals(other.Real) && Imaginary.Equals(other.Imaginary);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Complex) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary);
        }
    }
}