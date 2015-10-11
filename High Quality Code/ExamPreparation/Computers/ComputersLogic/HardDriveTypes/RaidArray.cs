namespace ComputersLogic.HardDriveTypes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RaidArray : HardDrive
    {
        private const string NoHardDrivesMessage = "No hard drive in the RAID array!";
        private IList<IHardDrive> hardDrivers;

        public RaidArray(IList<IHardDrive> hardDrives)
            : base()
        {
            this.hardDrivers = hardDrives;
        }

        public override int Capacity
        {
            get
            {
                if (!this.hardDrivers.Any())
                {
                    return 0;
                }

                return this.hardDrivers.First().Capacity;
            }
        }

        public override void SaveData(int address, string newData)
        {
            foreach (var hardDrive in this.hardDrivers)
            {
                hardDrive.SaveData(address, newData);
            }
        }

        public override string LoadData(int address)
        {
            if (!this.hardDrivers.Any())
            {
                throw new ArgumentOutOfRangeException(NoHardDrivesMessage);
            }

            return this.hardDrivers.First().LoadData(address);
        }
    }
}
