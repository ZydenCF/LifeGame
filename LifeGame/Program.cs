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

            Console.WriteLine("Welcome to Life Simulation!");
            Console.WriteLine("Choose your character:");
            Console.WriteLine("1. Human");
            Console.WriteLine("2. Robot");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Invalid choice. Please enter 1 for Human or 2 for Robot:");
            }

            if (choice == 1)
            {
                Human human = new Human(100, "Carlos");
                manager.AddCharacter(human);
            }
            else
            {
                Robot robot = new Robot(80, "C-3PO");
                manager.AddCharacter(robot);
            }

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
