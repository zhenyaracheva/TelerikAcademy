//Problem 7.* Arithmetical expressions

//Write a program that calculates the value of given arithmetical expression.

//The expression can contain the following elements only:
//Real numbers, e.g. 5, 18.33, 3.14159, 12.6
//Arithmetic operators: +, -, *, / (standard priorities)
//Mathematical functions: ln(x), sqrt(x), pow(x,y)
//Brackets (for changing the default priorities): (, )
//Examples:

//                      input	                        output
//(3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)	            ~10.6
//pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)	~21.22

using System;
using System.Collections.Generic;
using System.Text;

class SolveArithmeticalExpressions
{
    static private readonly List<char> arithmeticOperators = new List<char> { '+', '-', '*', '/' };
    static private readonly List<string> functions = new List<string>() { "ln", "pow", "sqrt" };
    static public readonly List<char> brackets = new List<char>() { '(', ')' };

    static void Main()
    {
        try
        {

            string input = Console.ReadLine().Trim();
            input = input.Replace(" ", string.Empty);
            var tokens = SeparateTokens(input);
            var reversed = ShuntingYardAlgorithm(tokens);
            double final = ReversePolishNotation(reversed);

            Console.WriteLine("Result: {0:F2}", final);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static double ReversePolishNotation(Queue<string> queue)
    {
        Stack<double> stack = new Stack<double>();

        while (queue.Count != 0)
        {
            string currentToken = queue.Dequeue();
            double number;

            if (double.TryParse(currentToken, out number))
            {
                stack.Push(number);
            }
            else if (arithmeticOperators.Contains(currentToken[0]) || functions.Contains(currentToken))
            {
                if (currentToken == "+")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double first = stack.Pop();
                    double second = stack.Pop();

                    stack.Push(first + second);
                }
                else if (currentToken == "-")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double second = stack.Pop();
                    double first = stack.Pop();

                    stack.Push(first - second);
                }
                else if (currentToken == "*")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double second = stack.Pop();
                    double first = stack.Pop();

                    stack.Push(first * second);
                }
                else if (currentToken == "/")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double second = stack.Pop();
                    double first = stack.Pop();

                    stack.Push(first / second);
                }
                else if (currentToken == "ln")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double first = stack.Pop();

                    stack.Push(Math.Log(first));
                }
                else if (currentToken == "pow")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double second = stack.Pop();
                    double first = stack.Pop();

                    stack.Push(Math.Pow(first, second));
                }
                else if (currentToken == "sqrt")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double first = stack.Pop();

                    stack.Push(Math.Sqrt(first));
                }
            }
        }

        if (stack.Count == 1)
        {
            return stack.Pop();
        }
        else
        {
            throw new ArgumentException("Inavlid expression!");
        }

    }

    private static Queue<string> ShuntingYardAlgorithm(List<string> tokens)
    {
        Stack<string> stack = new Stack<string>();
        Queue<string> queue = new Queue<string>();

        for (int i = 0; i < tokens.Count; i++)
        {
            string currentToken = tokens[i];
            double number;

            if (double.TryParse(currentToken, out number))
            {
                queue.Enqueue(currentToken);
            }
            else if (functions.Contains(currentToken))
            {
                stack.Push(currentToken);
            }
            else if (currentToken == ",")
            {
                if (!stack.Contains("(") && stack.Count != 0)
                {
                    throw new ArgumentException("Invalid brackets or function argument!");
                }

                while (stack.Peek() != "(")
                {
                    queue.Enqueue(stack.Pop());
                }
            }
            else if (arithmeticOperators.Contains(currentToken[0]))
            {
                while (stack.Count != 0 && arithmeticOperators.Contains(stack.Peek()[0]) &&
                     Precedence(currentToken) <= Precedence(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }

                stack.Push(currentToken);
            }
            else if (currentToken == "(")
            {
                stack.Push("(");
            }
            else if (currentToken == ")")
            {
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("Invalid brackets!");
                }

                while (stack.Peek() != "(")
                {
                    queue.Enqueue(stack.Pop());
                }

                stack.Pop();

                if (stack.Count != 0 && functions.Contains(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }
            }
        }

        if (stack.Count != 0)
        {
            if (brackets.Contains(stack.Peek()[0]))
            {
                throw new ArgumentException("Mismatched parentheses!");
            }

            while (stack.Count != 0)
            {
                queue.Enqueue(stack.Pop());
            }
        }

        return queue;
    }

    private static int Precedence(string arithmeticOperator)
    {
        if (arithmeticOperator == "+" || arithmeticOperator == "-")
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    private static List<string> SeparateTokens(string input)
    {
        List<string> tokens = new List<string>();
        StringBuilder number = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            char currentToken = input[i];


            if (currentToken == '-' && (i == 0 || input[i - 1] == '(' || input[i - 1] == ','))
            {
                number.Append(currentToken);
            }
            else if (char.IsDigit(currentToken) || currentToken == '.')
            {
                number.Append(currentToken);
            }
            else if (!char.IsDigit(input[i]) && number.Length != 0)
            {
                tokens.Add(number.ToString());
                number.Clear();
                i--;
            }
            else if (brackets.Contains(currentToken))
            {
                tokens.Add(currentToken.ToString());
            }
            else if (currentToken == ',')
            {
                tokens.Add(",");
            }
            else if (arithmeticOperators.Contains(currentToken))
            {
                tokens.Add(currentToken.ToString());
            }
            else if (i + 1 < input.Length && functions.Contains(input.Substring(i, 2).ToLower()))
            {
                tokens.Add("ln");
                i++;
            }
            else if (i + 2 < input.Length && functions.Contains(input.Substring(i, 3).ToLower()))
            {
                tokens.Add("pow");
                i += 2;
            }
            else if (i + 3 < input.Length && functions.Contains(input.Substring(i, 4).ToLower()))
            {
                tokens.Add("sqrt");
                i += 3;
            }
        }

        if (number.Length != 0)
        {
            tokens.Add(number.ToString());
        }

        return tokens;
    }
}

