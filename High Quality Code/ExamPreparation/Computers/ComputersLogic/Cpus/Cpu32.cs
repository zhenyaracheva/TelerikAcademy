namespace ComputersLogic.Cpus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cpu32 : Cpu
    {
         private int minaBitsValue = 500;

        public Cpu32(int numberOfCores)
            : base(numberOfCores)
        {
        }

        public override int MaxBitValue
        {
            get
            {
                return this.minaBitsValue;
            }
        }
    }
}
