namespace ComputersLogic
{
    public class Command : ICommand
    {
        public string Name { get; set; }

        public int Argument { get; set; }
    }
}
