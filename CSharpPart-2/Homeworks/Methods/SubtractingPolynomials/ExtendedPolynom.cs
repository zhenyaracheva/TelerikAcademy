namespace SubtractingPolynomials
{
    using System;
    using System.Linq;

    class ExtendedPolynom
    {
        static void Main(string[] args)
        {
            Console.Write("Please, enter first polynom (example: 3x^2 or only 3 if x^0): ");
            string firstPolynomString = Console.ReadLine();
            Polynom firstPolynom = ConvertStringToPolynom(firstPolynomString);

            Console.Write("Please, enter second polynom: ");
            string secondPolynomString = Console.ReadLine();
            Polynom secondPolynom = ConvertStringToPolynom(secondPolynomString);

            int[] add = OperatePolynoms(firstPolynom, secondPolynom, '+');
            int[] sub = OperatePolynoms(firstPolynom, secondPolynom, '-');
            int[] multuply = OperatePolynoms(firstPolynom, secondPolynom, '*');

            Console.WriteLine(string.Join(", ", add));
            Console.WriteLine(string.Join(", ", sub));
            Console.WriteLine(string.Join(", ", multuply));
        }

        private static Polynom ConvertStringToPolynom(string polynomString)
        {
            Polynom polynom;

            if (polynomString.Contains('x'))
            {
                if (polynomString.Contains('^'))
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
                    string[] parts = polynomString.Split(new char[] { 'x' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 0)
                    {
                        polynom = new Polynom(1, 1);
                    }
                    else
                    {
                        polynom = new Polynom(int.Parse(parts[0]), 1);
                    }
                }
            }
            else
            {
                polynom = new Polynom(int.Parse(polynomString), 0);
            }

            return polynom;
        }

        public static int[] OperatePolynoms(Polynom first, Polynom second, char operation)
        {
            int[] result;

            if (first.Exponent == second.Exponent)
            {
                result = new int[first.Exponent + 1];
                switch (operation)
                {
                    case '+': result[first.Exponent] = first.Coefficient + second.Coefficient;
                        break;
                    case '-': result[first.Exponent] = first.Coefficient - second.Coefficient;
                        break;
                    case '*': result[first.Exponent] = first.Coefficient * second.Coefficient;
                        break;
                    default: throw new ArgumentException("Invalid operation!");
                }
            }
            else
            {
                result = new int[first.Exponent > second.Exponent ? first.Exponent + 1 : second.Exponent + 1];
                result[first.Exponent] = first.Coefficient;
                if (operation == '-')
                {
                    result[second.Exponent] = second.Coefficient * (-1);
                }
                else
                {
                    result[second.Exponent] = second.Coefficient;
                }
            }

            return result;
        }
    }
}
