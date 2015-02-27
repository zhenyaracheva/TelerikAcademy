//Problem 4. Download file

//Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the current directory.
//Find in Google how to download files in C#.
//Be sure to catch all exceptions and to free any used resources in the finally block.

using System;
using System.Net;

class SolveDownloadFile
{
    static void Main()
    {
        try
        {
            WebClient webClient = new WebClient();
            Console.Write("Please, enter path: ");
            string path = Console.ReadLine();
            Console.Write("Please, enter file name: ");
            string fileName = Console.ReadLine();
            webClient.DownloadFile(path, fileName);
            Console.WriteLine("Image was downloaded successfully! Check \"bin\" directory to this project :)");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The address parameter is null.");
        }
        catch (WebException)
        {
            Console.WriteLine("The URI formed by combining BaseAddress and address is invalid, filename is null or Empty or the file does not exist.");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The method has been called simultaneously on multiple threads.");
        }
        finally
        {
            Console.WriteLine("Have a nice day :)");
        }
    }
}

