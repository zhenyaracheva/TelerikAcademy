namespace CommandPattern.Commands
{
    using CommandPattern.Commands.Common;
    using CommandPattern.Devices.Common;

    public class TurnOffCommand : Command, ICommand
    {
        public TurnOffCommand(IDevice device)
            : base(device)
        {
        }

        public override void Execute()
        {
            this.Device.TurnOff();
        }

        public override void Undo()
        {
            this.Device.TurnOn();
        }
    }
}
