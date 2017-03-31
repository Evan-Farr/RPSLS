using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    public class Game
    {
        public int round;
        public int gameMode;
        public Player player1;
        public Player player2;

        public void PlayGame()
        {
            DisplayPremise();
            DisplayRules();
            GetGameMode();
            while (player1.score < 3 && player2.score < 3)
            {
                PlayRound();
                AlertScore();
                Console.WriteLine("Hit [Enter] to continue.");
                Console.ReadLine();
            }
            AlertWinner();
            RequestNewGame();
            Console.WriteLine();
        }

        public void PlayRound()
        {
            Console.WriteLine("> " + player1.name + "'s turn: ");
            player1.GetChoice();
            AlertChoice(player1);
            Console.WriteLine();
            Console.WriteLine("> " + player2.name +"'s turn: ");
            player2.GetChoice();
            AlertChoice(player2);
            Console.WriteLine();
            DetermineWinner(player1.choice, player2.choice);
            Console.WriteLine();
        }

        public void DisplayPremise()
        {
            Console.WriteLine("In Rock, Paper, Scissors, Lizard, Spock you can either play against a friend or against the computer.");
            Console.WriteLine("The first player to win three rounds is the winner.");
            Console.WriteLine();
        }

        public void GetGameMode()
        {
            Console.WriteLine("Enter the number 1 or 2 to choose game mode: ");
            Console.WriteLine("[1] Human vs Human");
            Console.WriteLine("[2] Human vs Computer");
            gameMode = int.Parse(Console.ReadLine());  
            if(gameMode == 1)
            {
                player1 = new Human("Player1", 0);
                player2 = new Human("Player2", 0);
            }
            else if (gameMode == 2)
            {
                player1 = new Human("Player1", 0);
                player2 = new Computer(0);
            }
            Console.WriteLine();
            if(gameMode != 1 && gameMode != 2)
            {
                Console.WriteLine("You did not enter a valid input. Please enter only '1' or '2' as a choice");
                GetGameMode();
            }
        }

        public void DisplayRules()
        {
            Console.WriteLine("Rules: ");
            Console.WriteLine("> Scissors cuts Paper.");
            Console.WriteLine("> Scissors decapitates Lizard.");
            Console.WriteLine("> Paper covers Rock.");
            Console.WriteLine("> Paper disproves Spock.");
            Console.WriteLine("> Rock crushes Lizard.");
            Console.WriteLine("> Rock crushes Scissors.");
            Console.WriteLine("> Lizard poisons Spock.");
            Console.WriteLine("> Lizard eats Paper.");
            Console.WriteLine("> Spock smashes Scissors.");
            Console.WriteLine("> Spock vaporizes Rock.");
            Console.WriteLine();
        }

        public void DetermineWinner(int a, int b)
        {
            int determination = (5 + a - b) % 5;
            
            if(determination == 1 || determination == 3)
            {
                Console.WriteLine("Result: " + player1.name + " wins!");
                player1.score += 1;
            }else if(determination == 2 || determination == 4)
            {
                Console.WriteLine("Result: " + player2.name + " wins!");
                player2.score += 1;
            }else if(determination == 0)
            {
                Console.WriteLine("Result: Draw.");
            }
        }

        public void AlertChoice(Player player)
        {
            if(player.choice == 0)
            {
                Console.WriteLine(player.name + ": ROCK");
            }else if(player.choice == 1)
            {
                Console.WriteLine(player.name + ": PAPER");
            }else if (player.choice == 2)
            {
                Console.WriteLine(player.name + ": SCISSORS");
            }else if (player.choice == 3)
            {
                Console.WriteLine(player.name + ": SPOCK");
            }else if (player.choice == 4)
            {
                Console.WriteLine(player.name + ": LIZARD");
            }
        }

        public void AlertScore()
        {
            Console.WriteLine("Current Score: ");
            Console.WriteLine(player1.name + ": " + player1.score);
            Console.WriteLine(player2.name + ": " + player2.score);
            Console.WriteLine();
            Console.WriteLine();
        }

        public void AlertWinner()
        {
            if (player1.score == 3)
            {
                Console.WriteLine();
                Console.WriteLine("Game Over: ");
                Console.WriteLine(player1.name + " wins!");
            }
            else if (player2.score == 3)
            {
                Console.WriteLine();
                Console.WriteLine("Game Over: ");
                Console.WriteLine(player2.name + " wins!");
            }
        }

        public void RequestNewGame()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to play again? Enter 'yes' or 'no'.");
            string response = Console.ReadLine().ToLower();

            if(response == "yes")
            {
                Console.Clear();
                PlayGame();
            }else if(response == "no")
            {
                Console.Clear();
                Console.WriteLine("Thanks for playing!");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Hit [Enter] to quite.");
            }else
            {
                Console.WriteLine();
                Console.WriteLine("You did not enter a valid input. Please type only 'yes' or 'no' as an answer.");
                Console.WriteLine();
                RequestNewGame();
            }
        }
    }
}
