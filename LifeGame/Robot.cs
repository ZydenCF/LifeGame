using System;
using System.Collections.Generic;

namespace LifeGame
{
    class Robot : Character, IAction
    {
        private string model;
        private Random random;

        //Diccionario 
        private Dictionary<int, string> maintenanceTasks;

        //Lista
        private List<string> logs;

        //Pila
        private Stack<string> actions;

        //Cola
        private Queue<string> notifications;

        //Arreglo
        private string[] statusMessages = { "All systems nominal", "Warning: Low power", "Critical error detected" };

        //Constructor + Herencia
        internal Robot(int energy, string modelName) : base(energy) 
        {
            model = modelName;
            random = new Random();

            maintenanceTasks = new Dictionary<int, string>()
            {
                { 1, "Self-diagnostic" },
                { 2, "Oil joints" },
                { 3, "System update" }
            };

            logs = new List<string>();
            actions = new Stack<string>();
            notifications = new Queue<string>();
        }

        //Interfaz
        void IAction.DoAction(string option) 
        {
            Console.WriteLine(model + " executed: " + option);
            actions.Push(option); 
        }

        //Polimorfismo
        public override void Act(Simulation sim)
        {
            Console.WriteLine("\n--- Robot Maintenance Options ---");

            //For
            foreach (KeyValuePair<int, string> task in maintenanceTasks)
            {
                Console.WriteLine(task.Key + ". " + task.Value);
            }

            //Switch
            int choice = random.Next(1, maintenanceTasks.Count + 1);
            switch (choice)
            {
                case 1:
                    PerformTask("Self-diagnostic", sim);
                    break;
                case 2:
                    PerformTask("Oil joints", sim);
                    break;
                case 3:
                    PerformTask("System update", sim);
                    break;
                default:
                    Console.WriteLine(model + " did nothing.");
                    break;
            }

            //While
            int cycles = 0;
            while (cycles < 2 && notifications.Count > 0)
            {
                Console.WriteLine("Notification: " + notifications.Dequeue());
                cycles++;
            }

            Console.WriteLine(model + " status: " + GetStatus());
        }

        private void PerformTask(string task, Simulation sim) 
        {
            Console.WriteLine(model + " performed: " + task);
            logs.Add(task);

            //If else
            if (task == "Self-diagnostic")
            {
                Energy += 5;
                sim.Resources -= 2;
                notifications.Enqueue("Diagnostics complete.");
            }
            else if (task == "Oil joints")
            {
                Energy += 10;
                sim.Resources -= 5;
                notifications.Enqueue("Joints oiled.");
            }
            else
            {
                Energy -= 5;
                sim.Resources += 8;
                notifications.Enqueue("System updated.");
            }
        }

        //Return
        private string GetStatus()
        {
            //Array
            int index = random.Next(0, statusMessages.Length); 
            return statusMessages[index];
        }
    }
}
