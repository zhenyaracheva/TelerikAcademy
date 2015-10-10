namespace BridgePattern.RemoteControls
{
    using System;

    public class MuteRemoteControl : RemoteControl
    {
        public MuteRemoteControl()
            : base()
        {
        }

        public override void AbstractButtonPresed()
        {
            Console.WriteLine("Device was Muted!");
        }
    }
}
