using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    public class Human : Player
    {
        public Human(string Name, int Score)
        {
            name = Name;
            score = Score;
        }

        public override int GetChoice()
        {
            Console.WriteLine("Enter the number that correlates to what you want to throw down: \n");
            Console.WriteLine("Options: ");
            Console.WriteLine("[0] Rock");
            Console.WriteLine("[1] Paper");
            Console.WriteLine("[2] Scissors");
            Console.WriteLine("[3] Spock");
            Console.WriteLine("[4] Lizard");
            choice = int.Parse(Console.ReadLine());

            if(choice != 0 && choice != 1 && choice != 2 && choice != 3 && choice != 4)
            {
                Console.WriteLine("You did not enter a valid option. Please Try again: ");
                GetChoice();
            }
            return choice;
        }
    }
}
