//Problem 2. Print Company Information

//A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, 
//age and a phone number.
//Write a program that reads the information about a company and its manager and prints it back on the console.

using System;

class CompanyInformation
{
    static void Main()
    {
        Console.Write("Comnany name: ");
        string companyName = Console.ReadLine().Trim();

        Console.Write("Company address: ");
        string companyAddress = Console.ReadLine().Trim();

        Console.Write("Phone number: ");
        string phoneNumber = Console.ReadLine().Trim();

        Console.Write("Fax number: ");
        string faxNumber = Console.ReadLine().Trim();

        Console.Write("Web site: ");
        string webSite = Console.ReadLine().Trim();

        Console.Write("Manager first name: ");
        string managerFirstName = Console.ReadLine().Trim();

        Console.Write("Manager last name: ");
        string managerLastName = Console.ReadLine().Trim();

        Console.Write("Manager age: ");
        int managerAge = int.Parse(Console.ReadLine());

        Console.Write("Manager phone: ");
        string managerPhone = Console.ReadLine().Trim();

        Console.WriteLine(companyName);
        Console.WriteLine("Address: {0}", companyAddress);
        Console.WriteLine("Tel. {0}", phoneNumber);
        Console.WriteLine("Fax: {0}", faxNumber.Length < 6 ? "(no fax)" : faxNumber);
        Console.WriteLine("Web site: {0}", webSite);
        Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})", managerFirstName, managerLastName, managerAge, managerPhone);

    }
    //Telerik Academy
    //Address: 231 Al. Malinov, Sofia
    //Tel. +359 888 55 55 555
    //Fax: (no fax)
    //Web site: http://telerikacademy.com/
    //Manager: Nikolay Kostov (age: 25, tel. +359 2 981 981)  
}

