namespace ComputersLogic.HardDriveTypes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hdd : HardDrive
    {
        private int capacity;

        public Hdd(int capacity)
            : base()
        {
            this.capacity = capacity;
        }

        public override int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public override void SaveData(int address, string newData)
        {
            this.Data[address] = newData;
        }

        public override string LoadData(int address)
        {
            return this.Data[address];
        }
    }
}
