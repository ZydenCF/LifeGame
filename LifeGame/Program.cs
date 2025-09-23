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
            bool exitGame = false;

            while (!exitGame) //Menú principal
            {
                Console.Clear();
                Console.WriteLine("=== LIFE SIMULATION ===");
                Console.WriteLine("1. Play as Human");
                Console.WriteLine("2. Play as Robot");
                Console.WriteLine("3. Exit Game");
                Console.Write("Choose an option: ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 3))
                {
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3:");
                }

                if (choice == 3) //Exit the game
                {
                    exitGame = true;
                    Console.WriteLine("Goodbye!");
                    break;
                }

                //Simulation and Manager
                Simulation sim = new Simulation();
                GameManager manager = new GameManager();

                if (choice == 1) //Human
                {
                    Human human = new Human(100, "Carlos");
                    manager.AddCharacter(human);
                }
                else if (choice == 2) //Robot
                {
                    Robot robot = new Robot(80, "C-3PO");
                    manager.AddCharacter(robot);
                }

                //Cycle of days
                int day = 1;
                bool backToMenu = false;

                while (!backToMenu)
                {
                    Console.Clear();
                    manager.RunDay(day, sim);
                    day++;

                    Console.WriteLine("\n--- Options ---");
                    Console.WriteLine("1. Continue to next day");
                    Console.WriteLine("2. Show all days report");
                    Console.WriteLine("3. Return to main menu");
                    Console.WriteLine("4. Exit game");
                    Console.Write("Choose an option: ");

                    int gameChoice;
                    while (!int.TryParse(Console.ReadLine(), out gameChoice) || (gameChoice < 1 || gameChoice > 4))
                    {
                        Console.WriteLine("Invalid choice. Please enter 1, 2, 3, or 4:");
                    }

                    if (gameChoice == 1)
                    {
                        continue; //Play another day
                    }
                    else if (gameChoice == 2)
                    {
                        Console.Clear();
                        manager.ShowAllDays(); //Show Day history
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else if (gameChoice == 3)
                    {
                        backToMenu = true; // Return to the Main Menu
                    }
                    else
                    {
                        backToMenu = true;
                        exitGame = true;
                        Console.WriteLine("Goodbye!");
                    }
                }
            }
        }
    }
}
