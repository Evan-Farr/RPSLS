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
        public Player computer;


        public void PlayGame()
        {
            player1 = new Human("Player1", 0);
            player2 = new Human("Player2", 0);
            computer = new Computer(0);

            DisplayPremise();
            DisplayRules();
            GetGameMode();
            if (gameMode == 1)
            {
                while(player1.score < 3 && player2.score < 3)
                {
                    PlayHvHRound();
                    AlertHvHScore();
                    Console.WriteLine("Hit [Enter] to continue.");
                    Console.ReadLine();
                }
                AlertWinner();
                RequestNewGame();
                Console.WriteLine();
            }else if(gameMode == 2)
            {
                while (player1.score < 3 && computer.score < 3)
                {
                    PlayHvCRound();
                    AlertHvCScore();
                    Console.WriteLine("Hit [Enter] to continue.");
                    Console.ReadLine();
                }
                AlertWinner();
                RequestNewGame();
                Console.WriteLine();
            }
        }

        public void PlayHvHRound()
        {
            Console.WriteLine("> Player1's turn: ");
            player1.GetChoice();
            AlertPlayerOneChoice();
            Console.WriteLine();
            Console.WriteLine("> Player2's turn: ");
            player2.GetChoice();
            AlertPlayerTwoChoice();
            Console.WriteLine();
            DetermineWinnerHvH(player1.choice, player2.choice);
            Console.WriteLine();
        }

        public void PlayHvCRound()
        {
            Console.WriteLine("> Player1's turn: ");
            player1.GetChoice();
            AlertPlayerOneChoice();
            Console.WriteLine();
            Console.WriteLine("> Computer's turn: ");
            computer.GetChoice();
            AlertComputerChoice();
            Console.WriteLine();
            DetermineWinnerHvC(player1.choice, computer.choice);
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

        public void DetermineWinnerHvH(int a, int b)
        {
            int determination = (5 + a - b) % 5;
            
            if(determination == 1 || determination == 3)
            {
                Console.WriteLine("Result: Player1 wins!");
                player1.score += 1;
            }else if(determination == 2 || determination == 4)
            {
                Console.WriteLine("Result: Player2 wins!");
                player2.score += 1;
            }else if(determination == 0)
            {
                Console.WriteLine("Result: Draw.");
            }
        }

        public void DetermineWinnerHvC(int a, int b)
        {
            int determination = (5 + a - b) % 5;

            if (determination == 1 || determination == 3)
            {
                Console.WriteLine();
                Console.WriteLine("Result: You win!");
                Console.WriteLine();
                player1.score += 1;
            }
            else if (determination == 2 || determination == 4)
            {
                Console.WriteLine();
                Console.WriteLine("Result: The computer won.");
                Console.WriteLine();
                computer.score += 1;
            }
            else if (determination == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Result: Draw.");
                Console.WriteLine();
            }
        }

        public void AlertPlayerOneChoice()
        {
            if(player1.choice == 0)
            {
                Console.WriteLine("Player1 Chose: ROCK");
            }else if(player1.choice == 1)
            {
                Console.WriteLine("Player1 Chose: PAPER");
            }else if (player1.choice == 2)
            {
                Console.WriteLine("Player1 Chose: SCISSORS");
            }else if (player1.choice == 3)
            {
                Console.WriteLine("Player1 Chose: SPOCK");
            }else if (player1.choice == 4)
            {
                Console.WriteLine("Player1 Chose: LIZARD");
            }
        }

        public void AlertPlayerTwoChoice()
        {
            if (player2.choice == 0)
            {
                Console.WriteLine("Player2 Chose: ROCK");
            }
            else if (player2.choice == 1)
            {
                Console.WriteLine("Player2 Chose: PAPER");
            }
            else if (player2.choice == 2)
            {
                Console.WriteLine("Player2 Chose: SCISSORS");
            }
            else if (player2.choice == 3)
            {
                Console.WriteLine("Player2 Chose: SPOCK");
            }
            else if (player2.choice == 4)
            {
                Console.WriteLine("Player2 Chose: LIZARD");
            }
        }

        public void AlertComputerChoice()
        {
            if (computer.choice == 0)
            {
                Console.WriteLine("Computer Chose: ROCK");
            }
            else if (computer.choice == 1)
            {
                Console.WriteLine("Computer Chose: PAPER");
            }
            else if (computer.choice == 2)
            {
                Console.WriteLine("Computer Chose: SCISSORS");
            }
            else if (computer.choice == 3)
            {
                Console.WriteLine("Computer Chose: SPOCK");
            }
            else if (computer.choice == 4)
            {
                Console.WriteLine("Computer Chose: LIZARD");
            }
        }

        public void AlertHvHScore()
        {
            Console.WriteLine("Current Score: ");
            Console.WriteLine("Player1: " + player1.score);
            Console.WriteLine("Player2: " + player2.score);
            Console.WriteLine();
            Console.WriteLine();
        }

        public void AlertHvCScore()
        {
            Console.WriteLine("Current Score: ");
            Console.WriteLine("Player1: " + player1.score);
            Console.WriteLine("Computer: " + computer.score);
            Console.WriteLine();
            Console.WriteLine();
        }

        public void AlertWinner()
        {
            if(player1.score == 3)
            {
                Console.WriteLine();
                Console.WriteLine("Game Over: ");
                Console.WriteLine("Player1 wins!");
            }else if(player2.score == 3)
            {
                Console.WriteLine();
                Console.WriteLine("Game Over: ");
                Console.WriteLine("Player2 wins!");
            }else if(computer.score == 3)
            {
                Console.WriteLine();
                Console.WriteLine("Game Over: ");
                Console.WriteLine("Sorry, but the Computer spanked you.");
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
