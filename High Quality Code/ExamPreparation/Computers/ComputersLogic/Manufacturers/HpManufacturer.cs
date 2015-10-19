namespace ComputersLogic.Manufacturers
{
    using System.Collections.Generic;
    using ComputersLogic.ComputerTypes;
    using ComputersLogic.Cpus;
    using ComputersLogic.HardDriveTypes;
    using ComputersLogic.VideoCardTypes;

    public class HpManufacturer : IManufacturer
    {
        public PersonalComputer CreatePC()
        {
            var ram = new Ram(2);
            var videoCard = new ColorfulVideoCard();

            var pc = new PersonalComputer(
                new Cpu32(2),
                ram,
                new Hdd(500),
                videoCard);
            return pc;
        }

        public Laptop CreateLaptop()
        {
            var ram = new Ram(4);
            var videoCard = new ColorfulVideoCard();
            var laptop = new Laptop(
                 new Cpu64(2),
                 ram,
                 new Hdd(500),
                 videoCard,
                 new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var ram = new Ram(32);
            var videoCard = new MonochromeVideoCard();

            var server = new Server(
                new Cpu32(4),
                ram,
                new RaidArray(new List<IHardDrive> { new Hdd(1000), new Hdd(1000) }),
                videoCard);

            return server;
        }
    }
}
