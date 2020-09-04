using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchotteCase
{
    public class Game
    {
        public int NumberOfPlayes { get; set; }
        public int NumberOfRound { get; set; }

        public int CorrectAnswer { get;}

        private readonly int Max;


        public Game(int amountOfPlayers)
        {
            NumberOfRound = 0;
            NumberOfPlayes = amountOfPlayers;
            Max = MaxGuessingNumber();
            CorrectAnswer = GenerateRandomNumber();

        }

        public int MaxGuessingNumber()
        {
            if (NumberOfPlayes == 2)
            {
                return 100;
            }
            else if (NumberOfPlayes == 3)
            {
                return 250;
            }
            else
            {
                return 1000;
            }
        }

        public void CheckClosest(List<int> answers)
        {
            try
            {

                var closest = answers.OrderBy(x => Math.Abs(CorrectAnswer - x)).First();

                Console.WriteLine("closest player to guess the right answer is {0}", closest);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong!");
                Console.ResetColor();
            }

        }

        

        public List<int> Guesses()
        {
            List<int> answers = new List<int>();

            for (int i = 1; i <= NumberOfPlayes; i++)
            {
                try
                {
                    Console.WriteLine($"Player {i} give me a number between 1-{Max}! ");
                    answers.Add(Convert.ToInt32(Console.ReadLine()));
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
            }


            return answers;
        }

        public int GenerateRandomNumber()
        {
            var rand = new Random();
            return rand.Next(Max);
            
        }

        public int CheckWinner(List<int> answers)
        {
            try
            {
                var correct = CorrectAnswer;
                var closest = answers.OrderBy(x => Math.Abs(CorrectAnswer - x)).First();

                Console.WriteLine("The winner is the player who guessed number: " + closest + " The correct answer was: " + CorrectAnswer);
                return CorrectAnswer;


            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong!");
                Console.ResetColor();
                throw new Exception();


            }


        }
    }


}
