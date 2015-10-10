namespace CommandPattern.Commands
{
    using CommandPattern.Commands.Common;
    using CommandPattern.Devices.Common;

    public class VolumeDownCommand : Command, ICommand
    {
        public VolumeDownCommand(IDevice device)
            : base(device)
        {
        }

        public override void Execute()
        {
            this.Device.VolumeDown();
        }

        public override void Undo()
        {
            this.Device.VolumeUp();
        }
    }
}
