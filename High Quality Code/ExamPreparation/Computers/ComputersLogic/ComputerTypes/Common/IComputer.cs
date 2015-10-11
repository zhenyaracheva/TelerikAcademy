namespace ComputersLogic.ComputerTypes.Common
{
    using ComputersLogic.HardDriveTypes;
    using ComputersLogic.VideoCardTypes;

    public interface IComputer
    {
        Cpu Cpu { get; set; }

        Ram Ram { get; set; }

        IVideoCard VideoCard { get; set; }

        IHardDrive HardDrives { get; set; }
    }
}
