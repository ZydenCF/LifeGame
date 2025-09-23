using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Simulation sim = new Simulation();
            GameManager manager = new GameManager();

            Human human = new Human(100, "Carlos");
            manager.AddCharacter(human);

            int day = 1;
            while (true)
            {
                manager.RunDay(day, sim);
                day++;

                Console.WriteLine("Presiona una tecla para continuar al siguiente día...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
