namespace CommandPattern.Devices.Common
{
    public interface IDevice
    {
        void TurnOn();

        void TurnOff();

        void VolumeUp();

        void VolumeDown();
    }
}
