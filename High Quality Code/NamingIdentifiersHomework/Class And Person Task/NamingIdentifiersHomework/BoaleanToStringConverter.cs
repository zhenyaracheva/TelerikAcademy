namespace ClassTask
{
    using System;
   public class BooleanToStringConverter
    {
        public void PrintBoolToSting(bool promenliva)
        {
            string boolAsString = promenliva.ToString();
            Console.WriteLine(boolAsString);
        }
    }
}