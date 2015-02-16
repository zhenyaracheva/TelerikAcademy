//Problem 5. Parse tags

//You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to upper-case.
//The tags cannot be nested.
//Example: We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
//The expected result: We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

using System;
using System.Text;
class Tags
{
    static void Main()
    {
        Console.WriteLine("Please,enter text: ");
        string text = Console.ReadLine();
        StringBuilder converted = new StringBuilder();
        string startTag = "<upcase>";
        string endTag = "</upcase>";
        bool inTag = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '<')
            {
                if (text.Substring(i, startTag.Length) == startTag)
                {
                    inTag = true;
                    i += startTag.Length - 1;
                }
                else if (text.Substring(i, endTag.Length) == endTag)
                {
                    inTag = false;
                    i += endTag.Length - 1;
                }
                else
                {
                    converted.Append(text[i]);
                }
            }
            else if (char.IsDigit(text[i]) || inTag)
            {
                converted.Append(text[i].ToString().ToUpper());
            }
            else if (char.IsDigit(text[i]) || !inTag)
            {
                converted.Append(text[i]);
            }
        }

        Console.WriteLine(converted);
    }
}

