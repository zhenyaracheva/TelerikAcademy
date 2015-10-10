namespace CommandPattern.Devices
{
    using System;

    using CommandPattern.Devices.Common;

    public class Radio : Device, IDevice
    {
        public override void TurnOn()
        {
            Console.WriteLine("Radio is ON");
        }

        public override void TurnOff()
        {
            Console.WriteLine("Radio is OFF");
        }

        public override void VolumeUp()
        {
            Console.WriteLine("Radio volume up");
        }

        public override void VolumeDown()
        {
            Console.WriteLine("Radio volume down");
        }
    }
}
