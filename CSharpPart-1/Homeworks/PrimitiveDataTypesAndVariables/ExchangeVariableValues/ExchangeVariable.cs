//Problem 9. Exchange Variable Values

//Declare two integer variables a and b and assign them with 5 and 10 and after that exchange their values by using 
//some programming logic.
//Print the variable values before and after the exchange.

using System;

class ExchangeVariable
{
    static void Main()
    {
        int a = 5;
        int b = 10;

        Console.WriteLine("Variable a before changing: {0}", a);
        Console.WriteLine("Variable b before changing: {0}", b);

        int temp = a;
        a = b;
        b = temp;

        Console.WriteLine("Variable a after changing: {0}", a);
        Console.WriteLine("Variable b after changing: {0}", b);
    }
}
