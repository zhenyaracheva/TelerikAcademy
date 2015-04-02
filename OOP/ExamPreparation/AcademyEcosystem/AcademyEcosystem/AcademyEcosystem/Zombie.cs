using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        private const int ZombieSize = 0;
        private const int BitePoints = 10;

        public Zombie(string name, Point location)
            : base(name, location, Zombie.ZombieSize)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            return Zombie.BitePoints;
        }
    }
}
