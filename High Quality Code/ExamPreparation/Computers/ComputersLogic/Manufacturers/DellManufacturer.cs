namespace ComputersLogic.Manufacturers
{
    using System.Collections.Generic;
    using ComputersLogic.ComputerTypes;
    using ComputersLogic.Cpus;
    using ComputersLogic.HardDriveTypes;
    using ComputersLogic.VideoCardTypes;

    public class DellManufacturer : IManufacturer
    {
        public PersonalComputer CreatePC()
        {
            var ram = new Ram(8);
            var videoCard = new ColorfulVideoCard();
            var pc = new PersonalComputer(new Cpu64(4), ram, new Hdd(1000), videoCard);
            return pc;
        }

        public Laptop CreateLaptop()
        {
            var ram = new Ram(8);
            var videoCard = new ColorfulVideoCard();

            var laptop = new Laptop(
                new Cpu32(4),
                ram,
                new Hdd(1000),
                videoCard,
                new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var ram = new Ram(64);
            var videoCard = new MonochromeVideoCard();

            var server = new Server(
                new Cpu64(8),
                ram,
                new RaidArray(new List<IHardDrive> { new Hdd(2000), new Hdd(2000) }),
                videoCard);

            return server;
        }
    }
}
