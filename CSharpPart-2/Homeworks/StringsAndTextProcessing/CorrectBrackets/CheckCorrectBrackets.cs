//Problem 3. Correct brackets

//Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).

using System;
using System.Collections.Generic;
class CheckCorrectBrackets
{
    static void Main()
    {
        Console.Write("Please, enter an expression: ");
        string expression = Console.ReadLine();
        Stack<char> brackets = new Stack<char>();

        for (int i = 0; i < expression.Length; i++)
        {
            if(expression[i]=='(')
            {
                brackets.Push('(');
            }
            else if (expression[i]==')')
            {
                if(brackets.Count==0)
                {
                    Console.WriteLine("Invalid brackets!");
                    return;
                }

                brackets.Pop();
            }
        }

        if (brackets.Count!=0)
        {
            Console.WriteLine("Invalid brackets!");
        }
        else
        {
            Console.WriteLine("Correct brackets!");
        }
    }
}

