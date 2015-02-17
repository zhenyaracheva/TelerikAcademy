//Problem 12. Parse URL

//Write a program that parses an URL address given in the format: [protocol]://[server]/[resource] and extracts from it the 
//[protocol], [server] and [resource] elements.
//Example:

//                      URL	                                    Information
//http://telerikacademy.com/Courses/Courses/Details/212	        [protocol] = http 
//                                                              [server] = telerikacademy.com 
//                                                              [resource] = /Courses/Courses/Details/212

using System;
using System.Text;
using System.Text.RegularExpressions;

class ParsingURL
{
    static void Main()
    {
        Console.WriteLine("Please, enter an URL address:");
        string[] address = Console.ReadLine().Split(new char[]{':','/'},StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("[protocol]: {0}", address[0]);
        Console.WriteLine("[server]: {0}",address[1]);
        Console.WriteLine("[resource]: /{0}",string.Join("/",address,2,address.Length-2));
    }
}
