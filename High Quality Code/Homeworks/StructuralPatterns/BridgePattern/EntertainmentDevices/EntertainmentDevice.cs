namespace BridgePattern.EntertainmentDevices
{
    using BridgePattern.RemoteControls;

    public class EntertainmentDevice
    {      
        private readonly int chanelsSupported;
        private readonly int maxVolumeLevel;
        private IRemoteControl remoteControl;

        public EntertainmentDevice(IRemoteControl remoteControl, int chanels, int maxVolume)
        {
            this.remoteControl = remoteControl;
            this.chanelsSupported = chanels;
            this.maxVolumeLevel = maxVolume;
        }

        public void ChangeVolumeUp()
        {
            this.remoteControl.ButtonVolumeUpPressed(this.maxVolumeLevel);            
        }

        public void ChangeVolumeDown()
        {
            this.remoteControl.ButtonVolumeDownrPressed(this.maxVolumeLevel);
        }

        public void ChangeChanelUp()
        {
            this.remoteControl.ButtonChanelUpPressed(this.chanelsSupported);
        }

        public void ChangeChanelDown()
        {
            this.remoteControl.ButtonChanelDownPressed(this.chanelsSupported);
        }

        public void SpecialButtonPressed()
        {
            this.remoteControl.AbstractButtonPresed();
        }

        public void DeviceFeedback()
        {
            this.remoteControl.DeviceFeedback();
        }
    }
}
