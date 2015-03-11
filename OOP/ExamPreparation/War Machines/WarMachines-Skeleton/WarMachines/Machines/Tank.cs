namespace WarMachines.Machines
{
    using System.Text;
    using WarMachines.Interfaces;

    public class Tank : Machine, ITank, IMachine
    {
        private const double DefensePointsModifier = 30;
        private const double AttackPointsModifier = 40;
        private const double InithialHealthPoints = 100;


        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, InithialHealthPoints, attackPoints, defensePoints)
        {
            this.ToggleDefenseMode();
        }


        public bool DefenseMode { get; private set; }


        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefensePoints -= DefensePointsModifier;
                this.AttackPoints += AttackPointsModifier;
            }
            else
            {
                this.DefensePoints += DefensePointsModifier;
                this.AttackPoints -= AttackPointsModifier;
            }

            this.DefenseMode = !this.DefenseMode;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            string defenseModeAsString = this.DefenseMode ? ModeOn : ModeOff;
            result.AppendLine(string.Format(" *Defense: {0}", defenseModeAsString));

            return result.ToString().Trim();
        }
    }
}
