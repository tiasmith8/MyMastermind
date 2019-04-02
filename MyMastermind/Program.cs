using MyMastermind.Classes;
using System;

namespace MyMastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            string responsePlusOrMinus = "";
            bool validInput = false;
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            // Playing instructions
            Console.WriteLine("Welcome to the MyMastermind Game!\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Enter 4 numbers ranging from 1 to 6.");
            Console.WriteLine("You have 10 attempts to guess the correct numbers in the correct order.");
            Console.WriteLine("Example: 1346\n");

            // Create new game object that holds the correct guess
            Mastermind game = new Mastermind();

            //While number of tries isn't up
            while (game.RemainingAttempts > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Enter a Guess: ");
                string guessCombination = Console.ReadLine();

                // Check for valid input
                validInput = game.CheckValidInput(guessCombination);

                if (!validInput)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Invalid Format. Enter 4 numbers ranging from 1 to 6.\n");
                    Console.ResetColor();
                    continue;
                }

                //Check if the guess is correct
                responsePlusOrMinus = game.CheckGuess(guessCombination);
                Console.WriteLine($"{responsePlusOrMinus}");
                if (responsePlusOrMinus.Equals("++++"))
                {
                    Console.WriteLine("Congratulations, you won!");
                    return;
                }
            }
            // Correct response was not guessed
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You Lose.");
            Console.ResetColor();
        }
    }
}

