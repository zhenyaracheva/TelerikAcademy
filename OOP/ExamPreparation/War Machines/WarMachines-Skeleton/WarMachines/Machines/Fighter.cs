namespace WarMachines.Machines
{
    using System.Text;
    using WarMachines.Interfaces;

    public class Fighter : Machine, IFighter, IMachine
    {
        private const double InitialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, InitialHealthPoints, attackPoints, defensePoints)
        {
            this.StealthMode = stealthMode;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            string defenseModeAsString = this.StealthMode ? ModeOn : ModeOff;
            result.AppendLine(string.Format(" *Stealth: {0}", defenseModeAsString));

            return result.ToString().Trim();
        }
    }
}
