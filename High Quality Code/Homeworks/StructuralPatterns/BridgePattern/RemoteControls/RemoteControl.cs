namespace BridgePattern.RemoteControls
{
    using System;

    public abstract class RemoteControl : IRemoteControl
    {
        private int chanel;
        private int volumeLevel;

        public RemoteControl()
        {
            this.chanel = 1;
            this.volumeLevel = 0;
        }

        public void ButtonChanelUpPressed(int maxChanel)
        {
            this.chanel++;
            if (this.chanel > maxChanel)
            {
                this.chanel = 0;
            }
        }

        public void ButtonChanelDownPressed(int maxChanel)
        {
            this.chanel--;
            if (this.chanel < 0)
            {
                this.chanel = maxChanel;
            }
        }

        public void ButtonVolumeUpPressed(int maxVolume)
        {
            if (this.volumeLevel < maxVolume)
            {
                this.volumeLevel++;
            }

            Console.WriteLine("Volume at: " + this.volumeLevel);
        }

        public void ButtonVolumeDownrPressed(int maxVolume)
        {
            if (this.volumeLevel > maxVolume)
            {
                this.volumeLevel--;
            }

            Console.WriteLine("Volume at: " + this.volumeLevel);
        }

        public abstract void AbstractButtonPresed();

        public void DeviceFeedback()
        {
            Console.WriteLine("On Channel " + this.chanel);
        }
    }
}
