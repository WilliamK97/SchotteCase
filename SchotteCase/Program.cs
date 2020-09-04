using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchotteCase
{
    class Program
    {

        static void Main(string[] args)
        {

            bool continueProgram = true;
            var numberOfRounds = 0;

            Console.WriteLine("Welcome to Schottes guessing game!");

            var amountOfPlayers = AmountOfPLayers();


            while (continueProgram)
            {
                Game game = new Game(amountOfPlayers);
                while (game.NumberOfRound<= 3)
                {

                    var answers = game.Guesses();

                    if (answers.Any(x => x == game.CorrectAnswer))
                    {
                        Console.WriteLine("winner the correct answer is {0}", game.CorrectAnswer);
                        break;
                    }

                    game.CheckClosest(answers);
                    game.NumberOfRound++;
                    if (game.NumberOfRound == 3)
                    {
                        game.CheckWinner(answers);
                        break;
                    }

                }

                continueProgram = ContinueProgram();

            }
        }

        

        public static int AmountOfPLayers()
        {
            Console.WriteLine("Are you playing as 2, 3 or 4 people?");
            var amountOfPlayers = Convert.ToInt32(Console.ReadLine());

            if (amountOfPlayers == 2 || amountOfPlayers == 3 || amountOfPlayers == 4)
            {
                return amountOfPlayers;

            }
            return AmountOfPLayers();

        }

        

        public static bool ContinueProgram()
        {
            Console.WriteLine("Do you want to play again? Yes/No");

            var userAnswer = Console.ReadLine();
            return userAnswer.ToLower().Contains("yes") ? true : false;
        }
    }
}
