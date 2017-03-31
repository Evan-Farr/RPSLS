using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    public class Computer : Player
    {
        public Computer(int Score)
        {
            name = "Computer";
            score = Score;
        }

        public override int GetChoice()
        {
            Random random = new Random();
            choice = random.Next(5);
            return choice;
        }
    }
}
