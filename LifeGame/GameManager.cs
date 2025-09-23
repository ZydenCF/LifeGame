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
        private List<Day> days;

        internal GameManager()
        {
            actions = new Stack<string>();
            logs = new Queue<string>();
            characters = new List<Character>();
            days = new List<Day>();
        }

        internal void AddCharacter(Character c)
        {
            characters.Add(c);
        }

        internal void AddAction(string act)
        {
            actions.Push(act);
        }

        internal void RunDay(int dayNumber, Simulation sim)
        {
            Console.WriteLine(" Day " + dayNumber + " ");

            //Crear día
            Day currentDay = new Day(dayNumber);

            //Personajes actúan
            foreach (Character c in characters)
            {
                c.Act(sim);
                currentDay.AddAction(c.GetType().Name + " acted.");
            }

            //Recursos
            Console.WriteLine("Current resources: " + sim.Resources);

            //Registrar acciones 
            while (actions.Count > 0)
            {
                string act = actions.Pop();
                logs.Enqueue(act);
                Console.WriteLine(">> " + act);
                currentDay.AddAction("Action logged: " + act);
            }

            //Historial del día
            currentDay.SetSummary($"Resources after Day {dayNumber}: {sim.Resources}");
            currentDay.ShowDayReport();

            //Guardar día 
            days.Add(currentDay);

            Console.WriteLine(" Day " + dayNumber + " finished");
        }

        //mostrar historial
        internal void ShowAllDays()
        {
            Console.WriteLine("\n=== GAME HISTORY ===");
            foreach (Day d in days)
            {
                d.ShowDayReport();
            }
        }
    }
}
