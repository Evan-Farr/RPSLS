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
            string option = Console.ReadLine();

            if(option != "0" && option != "1" && option != "2" && option != "3" && option != "4")
            {
                Console.WriteLine();
                Console.WriteLine("You did not enter a valid option. Please Try again: ");
                GetChoice();
            }else
            {
                choice = Convert.ToInt32(option);
            }

            return choice;
        }
    }
}
