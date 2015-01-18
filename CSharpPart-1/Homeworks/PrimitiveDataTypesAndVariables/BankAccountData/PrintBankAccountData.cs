//Problem 11. Bank Account Data

//A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, 
//3 credit card numbers associated with the account.
//Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive 
//names.

using System;

class PrintBankAccountData
{
    static void Main()
    {
        string firstNameAccountHolder = "John";
        string middleNameAccountHolder = "Jonson";
        string lastNameAccountHolder = "Doe";
        long balance = 1234567891234;
        string bankName = "The bank";
        string iban = "BG12 BNBG 3456 7890 1234 56";
        long firstCreditCardNumber = 1234567890123456;
        long secondCreditCardNumber = 1234567890123457;
        long thirdCreditCardNumber = 1234567890123458;
    }
}

