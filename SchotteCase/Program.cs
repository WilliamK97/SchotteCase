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

            while (continueProgram)
            {
                var answers = StartGame();

                CheckWinner(answers);

                continueProgram = ContinueProgram();
            }
        }

        public static List<int> StartGame()
        {
            List<int> answers = new List<int>();

            Console.WriteLine("Welcome to Schottes guessing game!");

            //Player one
            try
            {
                Console.WriteLine("Player One, give me a number between 1-100!");
                var playerOne = Convert.ToInt32(Console.ReadLine());
                answers.Add(playerOne);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }

            //Player two
            try
            {
                Console.WriteLine("Player Two, give me a number between 1-100!");
                var playerTwo = Convert.ToInt32(Console.ReadLine());
                answers.Add(playerTwo);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }

            return answers;
        }

        public static int GenerateRandomNumber()
        {
            var rand = new Random();
            return rand.Next(101);
        }

        public static void CheckWinner(List<int> answers)
        {
            try
            {
                var correctAnswer = GenerateRandomNumber();
                var closest = answers.OrderBy(x => Math.Abs(correctAnswer - x)).First();

                Console.WriteLine("The winner is the player who guessed number: " + closest + " The correct answer was: " + correctAnswer);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restart the program. Something went wrong!");
                Console.ResetColor();
            }

        }

        public static bool ContinueProgram()
        {
            Console.WriteLine("Do you want to play again? Yes/No");

            var userAnswer = Console.ReadLine();
            return userAnswer.ToLower().Contains("yes") ? true : false;
        }
    }
}
