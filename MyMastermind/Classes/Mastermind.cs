using System;
using System.Collections.Generic;
using System.Text;

namespace MyMastermind.Classes
{
    public class Mastermind
    {
        /// <summary>
        /// Holds number of remaining attempts left.
        /// </summary>
        public int RemainingAttempts { get; private set; }

        /// <summary>
        /// Holds the correct answer.
        /// </summary>
        private readonly string randomlyGeneratedAnswer;

        /// <summary>
        /// Initialize the game.
        /// </summary>
        public Mastermind()
        {
            // User starts with 10 guesses
            this.RemainingAttempts = 10;

            // Create the number combination to guess
            Random rndNumber = new Random();
            int randomSeedValue;

            for(int i = 1; i <= 4; i++)
            {
                randomSeedValue = rndNumber.Next(1, 7);
                // Save the number to a string
                this.randomlyGeneratedAnswer += randomSeedValue;
            }

            // Console.WriteLine($"The Random Number is: {this.randomlyGeneratedAnswer}");
        }


        /// <summary>
        /// Checks that guess is a valid combination of numbers.
        /// </summary>
        /// <param name="guessCombination"></param>
        /// <returns></returns>
        public bool CheckValidInput(string guessCombination)
        {
            // Check for string not of length 4
            if(guessCombination.Length != 4)
            {
                return false;
            }

            // Check that all values are 1-6
            for(int i = 0; i < 4; i++)
            {
                if(!"123456".Contains(guessCombination[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Creates the response string.
        /// </summary>
        /// <param name="guessedCombination"></param>
        /// <returns></returns>
        public string CheckGuess(string guessedCombination)
        {
            string response = ""; // Will contain the +/-/empty string
            List<char> temp = new List<char>(randomlyGeneratedAnswer); // List to hold values and "x" out for correct number but in the wrong position
            List<char> tempGuessed = new List<char>(guessedCombination);
            int firstIndexOf = -1;

            // Check all numbers for correct spaces (+ case)
            for(int i = 0; i <= 3; i++)
            {
                if(tempGuessed[i] == temp[i])
                {
                    response += "+";
                    temp[i] = 'x';
                    tempGuessed[i] = '7';
                }
            }

            // Check any number to be correct in wrong place
            for (int i = 0; i <= 3; i++)
            {
                // Contains the number but in the wrong place
                if(temp.Contains(tempGuessed[i]))
                {
                    // Get the space of the number and mark it as used
                    firstIndexOf = temp.FindIndex(x => x == tempGuessed[i]);
                    if (firstIndexOf >= 0)
                    {
                        temp[firstIndexOf] = 'x'; // Take out of possible values to check
                        response += "-";
                    }
                }
            }

            this.RemainingAttempts -= 1;
            return response;
        }
    }
}
