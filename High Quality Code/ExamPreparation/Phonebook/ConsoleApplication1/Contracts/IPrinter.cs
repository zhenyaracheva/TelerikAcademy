namespace Phonebook.Printers
{
    public interface IPrinter
    {
        string GetAllText();

        void Print(string message);
    }
}
