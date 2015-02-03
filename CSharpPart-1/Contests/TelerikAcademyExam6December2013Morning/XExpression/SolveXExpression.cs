using System;

class SolveXExpression
{
    static void Main()
    {
        string expression = Console.ReadLine();

        decimal result = 0;

        char currentOperator = '+';
        int currentNumber = 0;

        bool inBrackets = false;

        decimal inBracketsResult = 0;
        char inBracketsOperator = '+';
        int inBracketsNumber = 0;

        foreach (var symbol in expression)
        {
            if (symbol == '(')
            {
                inBrackets = true;
            }
            else if (symbol == ')')
            {
                inBrackets = false;
                switch (currentOperator)
                {
                    case '+': result += inBracketsResult;
                        break;
                    case '-': result -= inBracketsResult;
                        break;
                    case '*': result *= inBracketsResult;
                        break;
                    case '/': result /= inBracketsResult;
                        break;
                }

                inBracketsResult = 0;
                inBracketsOperator = '+';
            }
            else if (inBrackets)
            {
                if (char.IsDigit(symbol))
                {
                    inBracketsNumber = symbol - '0';

                    switch (inBracketsOperator)
                    {
                        case '+': inBracketsResult += inBracketsNumber;
                            break;
                        case '-': inBracketsResult -= inBracketsNumber;
                            break;
                        case '*': inBracketsResult *= inBracketsNumber;
                            break;
                        case '/': inBracketsResult /= inBracketsNumber;
                            break;
                    }
                }
                else if (symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/')
                {
                    inBracketsOperator = symbol;
                }
            }
            else if (!inBrackets)
            {
                if (char.IsDigit(symbol))
                {
                    currentNumber = symbol - '0';

                    switch (currentOperator)
                    {
                        case '+': result += currentNumber;
                            break;
                        case '-': result -= currentNumber;
                            break;
                        case '*': result *= currentNumber;
                            break;
                        case '/': result /= currentNumber;
                            break;
                    }
                }
                else if (symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/')
                {
                    currentOperator = symbol;
                }
            }
        }

        Console.WriteLine("{0:F2}", result);
    }


}

