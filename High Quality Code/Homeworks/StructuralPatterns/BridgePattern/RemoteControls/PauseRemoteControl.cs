namespace BridgePattern.RemoteControls
{
    using System;

    public class PauseRemoteControl : RemoteControl
    {
        public PauseRemoteControl()
            : base()
        {
        }

        public override void AbstractButtonPresed()
        {
            Console.WriteLine("Device was Paused!");
        }
    }
}
