namespace CommandPattern.Commands.Common
{
    public interface ICommand
    {
        void Execute();

        void Undo();
    }
}
