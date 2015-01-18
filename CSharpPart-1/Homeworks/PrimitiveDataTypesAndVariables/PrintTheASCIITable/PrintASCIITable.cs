//Problem 14.* Print the ASCII Table

//Find online more information about ASCII (American Standard Code for Information Interchange) and write a 
//program that prints the entire ASCII table of characters on the console (characters from 0 to 255).

using System;
using System.Text;

class PrintASCIITable
{
    static void Main(string[] args)
    {
        Console.BufferHeight = 256;
        Console.OutputEncoding = Encoding.Unicode;

        for (int character = 0; character < 255; character++)
        {
            char symbol = (char)character;
            Console.WriteLine("{0} -> {1}", character, symbol);

        }
    }
}
