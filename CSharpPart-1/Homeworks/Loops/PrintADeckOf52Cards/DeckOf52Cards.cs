//Problem 4. Print a Deck of 52 Cards

//Write a program that generates and prints all possible cards from a standard deck of 52 cards (without the jokers). 
//The cards should be printed using the classical notation (like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).
//The card faces should start from 2 to A.
//Print each card face in its four possible suits: clubs, diamonds, hearts and spades. Use 2 nested for-loops and a switch-case statement

using System;
using System.Text;

class DeckOf52Cards
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        string[] cards = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        for (int cardNumber = 0; cardNumber < cards.Length; cardNumber++)
        {
            for (int color = 0; color < 4; color++)
            {
                switch (color)
                {
                    case 0: Console.Write("{0}{1}, ", cards[cardNumber], (char)5);
                        break;
                    case 1: Console.Write("{0}{1}, ", cards[cardNumber], (char)6);
                        break;
                    case 2: Console.Write("{0}{1}, ", cards[cardNumber], (char)3);
                        break;
                    case 3: Console.WriteLine("{0}{1}", cards[cardNumber], (char)4);
                        break;
                }
            }
        }

    }
}

