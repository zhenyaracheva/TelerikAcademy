namespace BridgePattern
{
    using System;

    using BridgePattern.EntertainmentDevices;
    using BridgePattern.RemoteControls;

    public class BridgePatternExample
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Test device with mute:");
            var tv = new EntertainmentDevice(new MuteRemoteControl(), 100, 100);
            tv.ChangeVolumeUp();
            tv.ChangeVolumeUp();
            tv.ChangeVolumeUp();
            tv.ChangeVolumeDown();
            tv.ChangeChanelUp();
            tv.DeviceFeedback();
            tv.SpecialButtonPressed();
            Console.WriteLine();

            Console.WriteLine("Test device with Pause:");
            var tv2 = new EntertainmentDevice(new PauseRemoteControl(), 100, 100);
            tv2.ChangeVolumeUp();
            tv2.ChangeVolumeUp();
            tv2.ChangeVolumeUp();
            tv2.ChangeVolumeDown();
            tv2.ChangeChanelUp();
            tv2.DeviceFeedback();
            tv2.SpecialButtonPressed();
        }
    }
}
