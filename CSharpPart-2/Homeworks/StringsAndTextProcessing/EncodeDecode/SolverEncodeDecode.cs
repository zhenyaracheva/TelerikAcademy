//Problem 7. Encode/decode

//Write a program that encodes and decodes a string using given encryption key (cipher).
//The key consists of a sequence of characters.
//The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter 
//of the string with the first of the key, the second – with the second, etc. When the last key 
//character is reached, the next is the first.

using System;
using System.Text;

class SolverEncodeDecode
{
    static void Main()
    {
        Console.Write("Please, enter text: ");
        string text = Console.ReadLine();

        Console.Write("Plaese, enter a key:");
        string key = Console.ReadLine();
        string encrypted = Encode(text.Trim(), key.Trim());

        string decripted = Decode(encrypted, key);

        Console.WriteLine(encrypted);
        Console.WriteLine(decripted);
    }

    private static string Encode(string text, string key)
    {
        StringBuilder chipher = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            chipher.Append((char)(text[i] ^ (key[i % key.Length])));
        }

        return chipher.ToString();
    }

    private static string Decode(string text, string key)
    {
        return Encode(text, key);
    }
}

