namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public Pilot(string initialName)
        {
            this.Name = initialName;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null empty.");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new ArgumentNullException("Machine cannot be null!");
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            var result = new StringBuilder();
            string pilotName = this.Name;
            string machinesCount = this.machines.Count == 0 ? "no" : this.machines.Count.ToString();
            string machinesVsMachine = this.machines.Count == 1 ? "machine" : "machines";
            result.Append(string.Format("{0} - {1} {2}", pilotName, machinesCount, machinesVsMachine));

            if (this.machines.Count !=0)
            {
                result.AppendLine();

                foreach (var machine in machines)
                {
                    result.AppendLine(machine.ToString());
                }
            }

            return result.ToString().Trim();
        }
    }
}
