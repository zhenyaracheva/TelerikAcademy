namespace CommandPattern.Commands.Common
{
    using CommandPattern.Devices.Common;

    public abstract class Command : ICommand
    {
        public Command(IDevice device)
        {
            this.Device = device;
        }

        public IDevice Device { get; set; }

        public abstract void Execute();
        
        public abstract void Undo();
    }
}
