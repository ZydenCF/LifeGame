using System;
using System.Collections.Generic;

namespace LifeGame
{
    class Day
    {
        private int dayNumber;                 
        private List<string> actions;          
        private string summary;

        //Builder
        internal Day(int number)
        {
            dayNumber = number;
            actions = new List<string>();
            summary = "";
        }

        //action of the day
        internal void AddAction(string action)
        {
            actions.Add(action);
        }

        //summary
        internal void SetSummary(string text)
        {
            summary = text;
        }

        //information of the day
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

        //dayNumber
        internal int GetDayNumber()
        {
            return dayNumber;
        }

        //summary
        internal string GetSummary()
        {
            return summary;
        }
    }
}
