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
            Console.WriteLine(name + " decided: " + option);
        }

        public override void Act(Simulation sim)
        {
            Console.WriteLine("--- Human Options ---");
            Console.WriteLine("1. Go to school");
            Console.WriteLine("2. Eat");
            Console.WriteLine("3. Sleep");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    bool escapo = random.Next(0, 2) == 0;
                    if (escapo)
                    {
                        Console.WriteLine(name + "ran away from school.");
                        sim.Resources = 5;
                    }
                    else
                    {
                        Console.WriteLine(name + "studied hard.");
                        sim.Resources = 10;
                    }
                    break;

                case 2:
                    Dictionary<int, string> food = new Dictionary<int, string>()
                    {
                        { 1, "Junk food" },
                        { 2, "Healthy food" }
                    };
                    int foodChoice = random.Next(1, 3);
                    Console.WriteLine(name + " comió: " + food[foodChoice]);

                    if (foodChoice == 1)
                        sim.Resources -= 5;
                    else
                        sim.Resources += 5;
                    break;

                case 3:
                    string[] sleep = { "Rest well", "Played PS5 all night" };
                    string result = sleep[random.Next(0, sleep.Length)];
                    Console.WriteLine(name + " " + result);

                    if (result == "He rested well")
                        sim.Resources += 5;
                    else
                        sim.Resources -= 10;
                    break;

                default:
                    Console.WriteLine(name + " did nothing.");
                    break;
            }
        }
    }
}

