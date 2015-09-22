namespace CommandPattern.Commands
{
    using CommandPattern.Commands.Common;
    using CommandPattern.Devices.Common;

    public class VolumeUpCommand : Command, ICommand
    {
        public VolumeUpCommand(IDevice device)
            : base(device)
        {
        }

        public override void Execute()
        {
            this.Device.VolumeUp();
        }

        public override void Undo()
        {
            this.Device.VolumeDown();
        }
    }
}
