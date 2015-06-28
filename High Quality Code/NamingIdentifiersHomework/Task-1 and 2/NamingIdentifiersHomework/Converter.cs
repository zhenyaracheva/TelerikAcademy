namespace ClassTask
{
    public class Converter
    {
        private const int MaxCount = 6;

        public static void Main()
        {
            BooleanToStringConverter instance = new BooleanToStringConverter();
            instance.PrintBoolToSting(true);
        }
    }
}