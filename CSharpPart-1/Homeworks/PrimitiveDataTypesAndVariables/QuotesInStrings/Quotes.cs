//Problem 7. Quotes in Strings

//Declare two string variables and assign them with following value: The "use" of quotations causes difficulties.
//Do the above in two different ways - with and without using quoted strings.
//Print the variables to ensure that their value was correctly defined.

using System;

class Quotes
{
    static void Main()
    {
        string quottedString = "The \"use\" of quotations causes difficulties.";
        string withoutQuotesString = "The use of quotations causes difficulties.";

        Console.WriteLine(quottedString);
        Console.WriteLine(withoutQuotesString);
    }
}

