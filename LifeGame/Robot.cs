using System;
using System.Collections.Generic;

namespace LifeGame
{
    class Robot : Character, IAction
    {
        private string model;
        private Random random;

        // Dictionary
        private Dictionary<int, string> maintenanceTasks;

        // List
        private List<string> logs;

        // Stack
        private Stack<string> actions;

        // Line
        private Queue<string> notifications;

        // Arrangement
        private string[] statusMessages = { "All systems nominal", "Warning: Low power", "Critical error detected" };

        // Constructor + Herencia
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

        // Interface
        void IAction.DoAction(string option)
        {
            Console.WriteLine(model + " executed: " + option);
            actions.Push(option);
        }

        // Polymorphism
        public override void Act(Simulation sim)
        {
            Console.WriteLine("\n--- Robot Maintenance Options ---");

            // For (look through the dictionary)
            foreach (KeyValuePair<int, string> task in maintenanceTasks)
            {
                Console.WriteLine(task.Key + ". " + task.Value);
            }

            Console.Write("Choose an action: ");
            int choice;

            // Validate input
            while (!int.TryParse(Console.ReadLine(), out choice) || !maintenanceTasks.ContainsKey(choice))
            {
                Console.WriteLine("Invalid choice. Try again:");
            }

            // Switch (use the selected action)
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

            // While (process notifications)
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

            // If else
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

        // Return
        private string GetStatus()
        {
            // Array
            int index = random.Next(0, statusMessages.Length);
            return statusMessages[index];
        }
    }
}
