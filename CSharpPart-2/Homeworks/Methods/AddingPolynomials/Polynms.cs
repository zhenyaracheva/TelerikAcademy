//Problem 11. Adding polynomials

//Write a method that adds two polynomials.
//Represent them as arrays of their coefficients.
//Example:

//x2 + 5 = 1x2 + 0x + 5 => {5, 0, 1}

namespace AddingPolynomials
{
    using System;
    using System.Linq;

    class Polynms
    {
        static void Main()
        {
            Console.Write("Please, enter first polynom (example: 3x^2 or only 3 if x^0): ");
            string firstPolynomString = Console.ReadLine();
            Polynom firstPolinom = ConvertStringToPolynom(firstPolynomString);

            Console.Write("Please, enter second polynom: ");
            string secondPolynomString = Console.ReadLine();
            Polynom secondPolynom = ConvertStringToPolynom(secondPolynomString);

            int[] result = Add(firstPolinom, secondPolynom);
            Console.WriteLine(string.Join(", ", result));
        }

        private static Polynom ConvertStringToPolynom(string polynomString)
        {
            Polynom polynom;

            if (polynomString.Contains('x'))
            {
                polynomString = polynomString.Replace("x^", " ");
                string[] parts = polynomString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 1)
                {
                    polynom = new Polynom(1, int.Parse(parts[0]));
                }
                else if (parts.Length > 1 && parts[0] == "-")
                {
                    polynom = new Polynom(-1, int.Parse(parts[1]));
                }
                else
                {
                    polynom = new Polynom(int.Parse(parts[0]), int.Parse(parts[1]));

                }

            }
            else
            {
                polynom = new Polynom(int.Parse(polynomString), 0);
            }


            return polynom;
        }

        public static int[] Add(Polynom first, Polynom second)
        {
            int[] result;

            if (first.Exponent == second.Exponent)
            {
                result = new int[first.Exponent + 1];
                result[first.Exponent] = first.Coefficient + second.Coefficient;
            }
            else
            {
                result = new int[first.Exponent > second.Exponent ? first.Exponent + 1 : second.Exponent + 1];
                result[first.Exponent] = first.Coefficient;
                result[second.Exponent] = second.Coefficient;
            }

            return result;
        }
    }

}
