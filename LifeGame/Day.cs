using System;
using System.Collections.Generic;

namespace LifeGame
{
    class Day
    {
        private int dayNumber;                 
        private List<string> actions;          
        private string summary;               

        //Constructor
        internal Day(int number)
        {
            dayNumber = number;
            actions = new List<string>();
            summary = "";
        }

        //acción del día
        internal void AddAction(string action)
        {
            actions.Add(action);
        }

        //resumen
        internal void SetSummary(string text)
        {
            summary = text;
        }

        //información del día
        internal void ShowDayReport()
        {
            Console.WriteLine($"\n=== Day {dayNumber} Report ===");

            foreach (string action in actions)
            {
                Console.WriteLine("- " + action);
            }

            Console.WriteLine("Summary: " + summary);
            Console.WriteLine("=============================\n");
        }

        //número de día
        internal int GetDayNumber()
        {
            return dayNumber;
        }

        //resumen
        internal string GetSummary()
        {
            return summary;
        }
    }
}
