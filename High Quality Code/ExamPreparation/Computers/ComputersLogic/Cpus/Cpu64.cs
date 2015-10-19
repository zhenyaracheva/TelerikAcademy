namespace ComputersLogic.Cpus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cpu64 : Cpu
    {
        private int minaBitsValue = 1000;

        public Cpu64(int numberOfCores)
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
