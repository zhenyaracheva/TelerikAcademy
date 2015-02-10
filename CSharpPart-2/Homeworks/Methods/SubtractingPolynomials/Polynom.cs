namespace SubtractingPolynomials
{
    using System;
    using System.Linq;

    class Polynom
    {
        public int Coefficient { get; set; }
        public int Exponent { get; set; }

        public Polynom(int coefficient)
        {
            this.Coefficient = coefficient;
            this.Exponent = 0;
        }

        public Polynom(int coefficient, int exponent)
        {
            this.Coefficient = coefficient;
            this.Exponent = exponent;
        }

        public override string ToString()
        {
            return ((Exponent == 0) ? Coefficient.ToString() : (Coefficient + "x^" + Exponent).ToString());
        }
    }
}
