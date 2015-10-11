namespace ComputersLogic.ComputerTypes
{
    using System.Collections.Generic;

    using ComputersLogic.ComputerTypes.Common;
    using ComputersLogic.HardDriveTypes;
    using ComputersLogic.VideoCardTypes;

    public class Laptop : Computer
    {
        private const string BatteryStatusFormat = "Battery status: {0}%";
        private LaptopBattery battery;

        public Laptop(Cpu cpu, Ram ram, IHardDrive hardDrives, IVideoCard videoCard, LaptopBattery battery)
            : base(cpu, ram, hardDrives, videoCard)
        {
            this.battery = battery;
        }

        public LaptopBattery Battery
        {
            get
            {
                return this.battery;
            }
        }

        public void ChargeBattery(int percentage)
        {
            this.Battery.Charge(percentage);
            this.VideoCard.Draw(string.Format(BatteryStatusFormat, this.Battery.Percentage));
        }
    }
}
