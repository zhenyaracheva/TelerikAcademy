//Problem 3. Check for a Play Card

//Classical play cards use the following signs to designate the card face: `2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. 
//Write a program that enters a string and prints “yes” if it is a valid card sign or “no” otherwise. 

using System;
using System.Collections.Generic;

class CheckPlayCard
{
    static void Main()
    {
        List<string> cards = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        Console.Write("Enter card: ");
        string card = Console.ReadLine();

        Console.WriteLine("Is valid card {0}? {1}", card, cards.Contains(card) ? "Yes!" : "No!");
    }
}

