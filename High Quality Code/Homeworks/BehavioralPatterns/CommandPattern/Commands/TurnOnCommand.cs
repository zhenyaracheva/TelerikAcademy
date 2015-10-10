namespace CommandPattern.Commands
{
    using CommandPattern.Commands.Common;
    using CommandPattern.Devices.Common;

    public class TurnOnCommand : Command, ICommand
    {
        public TurnOnCommand(IDevice device)
            : base(device)
        {
        }

        public override void Execute()
        {
            this.Device.TurnOn();
        }

        public override void Undo()
        {
            this.Device.TurnOff();
        }
    }
}
