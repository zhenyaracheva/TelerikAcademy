namespace Phonebook.Printers
{
    using System.Text;

    public class Printer : IPrinter
    {
        private StringBuilder input = new StringBuilder();

        public void Print(string text)
        {
            this.input.AppendLine(text);
        }

        public string GetAllText()
        {
            return this.input.ToString();
        }
    }
}
