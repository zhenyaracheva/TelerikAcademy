//Problem 12. Index of letters

//Write a program that creates an array containing all letters from the alphabet (A-Z).
//Read a word from the console and print the index of each of its letters in the array.

using System;

class FindIndexOfLetters
{
    const int StarIndexOfLetters = 65;

    static void Main()
    {
        char[] arrayOfAllLetters = new char[26];
        arrayOfAllLetters = FillArrayWithLetters(arrayOfAllLetters);

        Console.Write("Please, enter a word: ");
        string word = CheckStringVAlidation();

        string wordToUpper = word.ToUpper();
        int index = 0;

        foreach (var letter in wordToUpper)
        {
            for (int i = 0; i < arrayOfAllLetters.Length; i++)
            {
                if (arrayOfAllLetters[i] == letter)
                {
                    Console.WriteLine("{0} has index {1}", word[index], ((int)letter - StarIndexOfLetters));
                }
            }
            index++;
        }
    }

    private static string CheckStringVAlidation()
    {
        string word = Console.ReadLine();

        while(word.Length<=0)
        {
            Console.Write("Invalid word! Write another one: ");
            word = Console.ReadLine();
        }

      while(true)
      {
          bool passed = true;

          for (int i = 0; i < word.Length; i++)
          {
              if (!char.IsLetter(word[i]))
              {
                  passed = false;
              }
          }

          if (!passed)
          {
              Console.Write("Word must cointains only letters! Write another word: ");
              word = Console.ReadLine();
          }
          else
          {
              break;
          }
      }

        return word;
    }

    private static char[] FillArrayWithLetters(char[] arrayOfAllLetters)
    {
        for (int i = 0; i < arrayOfAllLetters.Length; i++)
        {
            arrayOfAllLetters[i] = (char)(i + StarIndexOfLetters);
        }

        return arrayOfAllLetters;
    }
}

