namespace ComputersLogic.ComputerTypes
{
    using ComputersLogic.ComputerTypes.Common;
    using ComputersLogic.HardDriveTypes;
    using ComputersLogic.VideoCardTypes;

    public class Server : Computer
    {
        public Server(Cpu cpu, Ram ram, IHardDrive hardDrives, IVideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Process(int data)
        {
            Ram.SaveValue(data);
            Cpu.SquareNumber();
        }
    }
}
