using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class Human : Character, IAction
    {
        private Random random;
        private string name;

        internal Human(int energy, string nameHuman) : base(energy)
        {
            random = new Random();
            name = nameHuman;
        }

        void IAction.DoAction(string option)
        {
            Console.WriteLine(name + " decidió: " + option);
        }

        public override void Act(Simulation sim)
        {
            Console.WriteLine("\n--- Opciones del Humano ---");
            Console.WriteLine("1. Ir al colegio");
            Console.WriteLine("2. Comer");
            Console.WriteLine("3. Dormir");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    bool escapo = random.Next(0, 2) == 0;
                    if (escapo)
                    {
                        Console.WriteLine(name + " escapó del colegio.");
                        sim.Resources -= 5;
                    }
                    else
                    {
                        Console.WriteLine(name + " estudió mucho.");
                        sim.Resources += 10;
                    }
                    break;

                case 2:
                    Dictionary<int, string> food = new Dictionary<int, string>()
                    {
                        { 1, "Comida chatarra" },
                        { 2, "Comida saludable" }
                    };
                    int foodChoice = random.Next(1, 3);
                    Console.WriteLine(name + " comió: " + food[foodChoice]);

                    if (foodChoice == 1)
                        sim.Resources -= 5;
                    else
                        sim.Resources += 5;
                    break;

                case 3:
                    string[] sleep = { "Descansó bien", "Jugó PS5 toda la noche" };
                    string result = sleep[random.Next(0, sleep.Length)];
                    Console.WriteLine(name + " " + result);

                    if (result == "Descansó bien")
                        sim.Resources += 5;
                    else
                        sim.Resources -= 10;
                    break;

                default:
                    Console.WriteLine(name + " no hizo nada.");
                    break;
            }
        }
    }
}

