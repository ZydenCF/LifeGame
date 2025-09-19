using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    abstract class Character
    {
        protected int Energy { get; set; }
        protected Character(int startingEnergy)
        {
            Energy = startingEnergy;
        }

        public abstract void Act(Simulation sim);
    }
}
