namespace ComputersLogic.HardDriveTypes
{
    using System.Collections.Generic;

    public abstract class HardDrive : IHardDrive
    {
        private Dictionary<int, string> data;

        public HardDrive()
        {
            this.data = new Dictionary<int, string>();
        }
       
        public abstract int Capacity { get; }

        protected Dictionary<int, string> Data 
        {
            get
            {
                return this.data;
            }
        }

        public abstract void SaveData(int address, string newData);

        public abstract string LoadData(int address);
    }
}
