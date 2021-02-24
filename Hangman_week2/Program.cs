using System;

namespace Hangman_week2
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            /*
             * Your assignment is to create a game called Hangman. 
             * Hangman game is a pen and pencil guessing game for two or more players. 
             * You can read more about it https://en.wikipedia.org/wiki/Hangman_(game).
             * 
             * Done: One player (in our case the application) thinks of a word and the other player(s) tries to guess it by suggesting letters. 
             * The word to guess is represented by a row of dashes where each dash represents a letter in the word.
             * 
             * Game Rules to implement:
             *   • The player has 10 guesses to complete the word before losing the game.
             *   • The player can make two type of guesses:
             *   • Guess for a specific letter. If player guess a letter that occurs in the word, the program should update by inserting the letter in the correct position(s).
             *   • Guess for the whole word. The player type in a word he/she thinks is the word. If the guess is correct player wins the game and the whole word is revealed. If the word is incorrect nothing should get revealed.
             *   • If the player guesses the same letter twice, the program will not consume a guess.
             * 
             * Code Requirements:
             *   Done: • The secret word should be randomly chosen from an array of Strings.
             *   • The incorrect letters the player has guessed, should be put inside a StringBuilder and presented to the player after each guess.
             *   • The correct letters should be put inside a char array. Unrevealed letters need to be represented by a lower dash ( _ ).
             * 
            */

            //One player (in our case the application) thinks of a word and the other player(s) tries to guess it by suggesting letters. 
            Console.WriteLine(@"Hello dear user, time to play the handing man game! \nAnd I have choosen to use body parts as secret word. \nWicked huuh! ;)");

            string bodypart = RandomBodyparts();
            char[] guesses = new char[bodypart.Length];

            for (int i = 0; i <guesses.Length; i++)
                guesses[i] = '_';

            Console.WriteLine($"I'l help you out a little... the word is {bodypart.Length.ToString()} letter long. Good luck :)");

            for (int i = 0; i <10; ++i)
            {
                PrintGuessesToConsole(guesses);

                char guess = char.Parse(Console.ReadLine());
                bool result = ProcessGuess(guess);
                if (result)
                {
                    //say congrats
                }
                else
                {
                    //say try again?

                    //break loop if guessed the word?
                    break;
                }

            }
        }
        static void PrintGuessesToConsole(char[] guesses) 
        {
            //Loopa igenom alla värden och skriv till konsol
            foreach (char c in guesses)
            {
                Console.WriteLine(guesses.ToString());
            }
        }
        static bool ProcessGuess(char guess)
        {
            bool ret = false;

            //loopa en matchning, om match stoppa in bokstaven i char arrayen på rätt plats.

            return ret;
        }

        /// The secret word should be randomly chosen from an array of Strings.
        static string RandomBodyparts()
        {
            string[] bodyparts = { "Tooth", "Foot", "Leg", "Back", "Brain", "Heart", "Waist", "Hip", "Arm", "Liver" };
            return bodyparts[rnd.Next(bodyparts.Length)];
        }
    }
}
