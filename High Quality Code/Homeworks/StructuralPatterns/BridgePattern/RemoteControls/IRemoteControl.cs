namespace BridgePattern.RemoteControls
{
    public interface IRemoteControl
    {
        void ButtonChanelUpPressed(int maxChanel);

        void ButtonChanelDownPressed(int maxChanel);

        void ButtonVolumeUpPressed(int maxVolumeLevel);

        void ButtonVolumeDownrPressed(int maxVolumeLevel);

        void AbstractButtonPresed();

        void DeviceFeedback();
    }
}
