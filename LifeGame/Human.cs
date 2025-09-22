using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class Human : Character, IAction
    {
        private string name;

        private string[] opciones = { "Ir al colegio", "Comer", "Dormir" };

        private List<string> history;
        private Stack<string> undone;
        private Queue<string> pending;
        private Dictionary<int, string> actions;

        private Random rnd;

        public Human(string nombre)
        {
            this.name = nombre;
            history = new List<string>();
            undone = new Stack<string>();
            pending = new Queue<string>();
            actions = new Dictionary<int, string>()
            {
                { 1, "Ir al colegio" },
                { 2, "Comer" },
                { 3, "Dormir" }
            };
            rnd = new Random();
        }

        public string GetNameUpper(bool shout)
        {
            Func<string, string> toUpper = s => s.ToUpper();
            if (shout)
                return toUpper(name);
            else
                return name;
        }

        public void DoAction(Simulation sim)
        {
            Act(sim);
        }

        public override void Act(Simulation sim)
        {
            Console.WriteLine("¿Qué debe hacer el humano?");
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + opciones[i]);
            }

            string opcion = Console.ReadLine();
            int choice;
            if (!int.TryParse(opcion, out choice))
            {
                Console.WriteLine("Entrada inválida.");
                return;
            }

            int luck = rnd.Next(0, 2); // 0 o 1

            switch (choice)
            {
                case 1: // Colegio
                    if (luck == 0)
                    {
                        Console.WriteLine(name + " se fue a estudiar.");
                        Energy -= 5;
                        sim.Resources += 10;
                        history.Add("Estudió en el colegio");
                    }
                    else
                    {
                        Console.WriteLine(name + " escapó del colegio.");
                        Energy -= 10;
                        sim.Resources -= 5;
                        history.Add("Escapó del colegio");
                    }
                    break;

                case 2: // Comida
                    if (luck == 0)
                    {
                        Console.WriteLine(name + " comió comida chatarra.");
                        Energy -= 5;
                        sim.Resources -= 5;
                        history.Add("Comió comida chatarra");
                    }
                    else
                    {
                        Console.WriteLine(name + " comió comida saludable.");
                        Energy += 10;
                        sim.Resources -= 10;
                        history.Add("Comió comida saludable");
                    }
                    break;

                case 3: // Dormir
                    if (luck == 0)
                    {
                        Console.WriteLine(name + " se fue a descansar.");
                        Energy += 15;
                        history.Add("Durmió bien");
                    }
                    else
                    {
                        Console.WriteLine(name + " jugó en PS5 toda la noche.");
                        Energy -= 15;
                        history.Add("Se desveló jugando PS5");
                    }
                    break;

                default:
                    Console.WriteLine("Opción inválida, no hizo nada.");
                    break;
            }
        }

        public int GetEnergy()
        {
            return Energy;
        }
    }