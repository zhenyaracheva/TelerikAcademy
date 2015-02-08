﻿//Problem 1. Say Hello

//Write a method that asks the user for his name and prints “Hello, <name>”
//Write a program to test this method.
//Example:

//input     	   output
//Peter	        Hello, Peter!

using System;

class HelloMethod
{
    static void Main()
    {
        Console.Write("Please, enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine(SayHello(name));
    }

    private static string SayHello(string name)
    {
        return string.Format("Hello, {0}!", name);
    }
}
