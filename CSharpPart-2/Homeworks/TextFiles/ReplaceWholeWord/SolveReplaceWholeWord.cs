//Problem 8. Replace whole word

//Modify the solution of the previous problem to replace only whole words (not strings).

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class SolveReplaceWholeWord
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader(@"..\..\input.txt"))
        {
            using (StreamWriter writer = new StreamWriter(@"..\..\output.txt"))
            {
                string line = reader.ReadLine();
                StringBuilder result = new StringBuilder();

                while (line != null)
                {
                    var replaced = Regex.Replace(line, @"\bstart\b", "finish");
                    result.AppendLine(replaced);
                    line = reader.ReadLine();
                }

                writer.WriteLine(result);
            }
        }

        Console.WriteLine("Done!");
    }
}

