namespace CommandPattern.Devices.Common
{
    public abstract class Device : IDevice
    {
        public abstract void TurnOn();

        public abstract void TurnOff();

        public abstract void VolumeUp();

        public abstract void VolumeDown();
    }
}
