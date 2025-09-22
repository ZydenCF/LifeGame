using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class GameManager
    {
        private Human human;
        private Simulation sim;
        private int day;

        public GameManager()
        {
            sim = new Simulation();
            human = new Human("Jugador");
            day = 1;
        }

        public void StartGame()
        {
            while (true) 
            {
                Console.WriteLine(" Día " + day + " iniciado ");
                human.DoAction(sim);

                Console.WriteLine("Energía actual: " + human.GetEnergy());
                Console.WriteLine("Recursos actuales: " + sim.Resources);

                Console.WriteLine(" Día " + day + " terminado ");
                day++;
            }
        }
    }
}
