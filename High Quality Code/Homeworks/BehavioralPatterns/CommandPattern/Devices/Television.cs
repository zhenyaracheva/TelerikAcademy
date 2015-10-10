namespace CommandPattern.Devices
{
    using System;

    using CommandPattern.Devices.Common;

    public class Television : Device, IDevice
    {
        public override void TurnOn()
        {
            Console.WriteLine("TV is ON");
        }

        public override void TurnOff()
        {
            Console.WriteLine("TV is OFF");
        }

        public override void VolumeUp()
        {
            Console.WriteLine("TV volume up");
        }

        public override void VolumeDown()
        {
            Console.WriteLine("TV volume down");
        }
    }
}
