namespace ComputersLogic.Cpus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cpu128 : Cpu
    {
        private int maxBitValue = 2000;

        public Cpu128(int numberOfCores)
            : base(numberOfCores)
        {
        }

        public override int MaxBitValue
        {
            get 
            {
                return this.maxBitValue;    
            }
        }
    }
}
