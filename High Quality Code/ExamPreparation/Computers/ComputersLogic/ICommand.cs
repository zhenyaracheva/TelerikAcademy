namespace ComputersLogic
{
    public interface ICommand
    {
        string Name { get; set; }

        int Argument { get; set; }
    }
}
