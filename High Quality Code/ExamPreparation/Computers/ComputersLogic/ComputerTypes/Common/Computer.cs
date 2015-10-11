namespace ComputersLogic.ComputerTypes.Common
{
    using ComputersLogic.HardDriveTypes;
    using ComputersLogic.VideoCardTypes;

    public abstract class Computer : IComputer
    {
        private IMotherboard motherboard;

        public Computer(Cpu cpu, Ram ram, IHardDrive hardDrives, IVideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
            this.motherboard = new Motherboard(this.Cpu, ram, videoCard);
        }

        public IHardDrive HardDrives { get; set; }

        public IVideoCard VideoCard { get; set; }

        public Cpu Cpu { get; set; }

        public Ram Ram { get; set; }
    }
}
