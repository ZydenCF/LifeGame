using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class GameManager
    {
        private Stack<string> actions;
        private Queue<string> logs;
        private List<Character> characters;

        internal GameManager()
        {
            actions = new Stack<string>();
            logs = new Queue<string>();
            characters = new List<Character>();
        }

        internal void AddCharacter(Character c)
        {
            characters.Add(c);
        }

        internal void AddAction(string act)
        {
            actions.Push(act);
        }

        internal void RunDay(int day, Simulation sim)
        {
            Console.WriteLine(" Día " + day + " ");

            foreach (Character c in characters)
            {
                c.Act(sim); 
            }

            Console.WriteLine("Recursos actuales: " + sim.Resources);

            while (actions.Count > 0)
            {
                string act = actions.Pop();
                logs.Enqueue(act);
                Console.WriteLine(">> " + act);
            }

            logs.ToList().ForEach(x => Console.WriteLine("Historial: " + x));

            Console.WriteLine(" Día " + day + " terminado");
        }
    }
}
