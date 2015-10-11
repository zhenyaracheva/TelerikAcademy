namespace ComputersLogic.Manufacturers
{
    using System.Collections.Generic;

    using ComputersLogic.ComputerTypes;
    using ComputersLogic.HardDriveTypes;
    using ComputersLogic.VideoCardTypes;

    public class LenovoManufacturer : IManufacturer
    {
        public PersonalComputer CreatePC()
        {
            var ram = new Ram(4);
            var videoCard = new MonochromeVideoCard();
            var pc = new PersonalComputer(new Cpu(2, 64), ram, new Hdd(2000), videoCard);
            return pc;
        }

        public Laptop CreateLaptop()
        {
            var ram = new Ram(16);
            var videoCard = new ColorfulVideoCard();

            var laptop = new Laptop(
                new Cpu(2, 64),
                ram,
                new Hdd(1000),
                videoCard,
                new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var ram = new Ram(8);
            var videoCard = new MonochromeVideoCard();

            var server = new Server(
                new Cpu(2, 128),
                ram,
                new RaidArray(new List<IHardDrive> { new Hdd(2000), new Hdd(500) }),
                videoCard);

            return server;
        }
    }
}
