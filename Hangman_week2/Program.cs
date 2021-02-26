using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;

namespace Hangman_week2
{
    public class Program
    {
        static void Main()
        {

            /*
            * Your assignment is to create a game called Hangman. 
            * Hangman game is a pen and pencil guessing game for two or more players. 
            * You can read more about it https://en.wikipedia.org/wiki/Hangman_(game).
            * 
            * Done: One player (in our case the application) thinks of a word and the other player(s) tries to guess it by suggesting letters. 
            * Done: The word to guess is represented by a row of dashes where each dash represents a letter in the word.
            * 
            * Game Rules to implement:
            *   Done: • The player has 10 guesses to complete the word before losing the game.
            *   
            *   • The player can make two type of guesses:
            *   Done: • Guess for a specific letter. If player guess a letter that occurs in the word, the program should update by inserting the letter in the correct position(s).
            *   Done? • Guess for the whole word. The player type in a word he/she thinks is the word. If the guess is correct player wins the game and the whole word is revealed. If the word is incorrect nothing should get revealed.
            *   Done: • If the player guesses the same letter twice, the program will not consume a guess.
            * 
            * Code Requirements:
            *   Done: • The secret word should be randomly chosen from an array of Strings.
            *   Done: • The incorrect letters the player has guessed, should be put inside a StringBuilder and presented to the player after each guess.
            *   Done: • The correct letters should be put inside a char array. Unrevealed letters need to be represented by a lower dash ( _ ).
            * 
           */

            //One player (in our case the application) thinks of a word and the other player(s) tries to guess it by suggesting letters. 
            Console.WriteLine($"Hello dear user, time to play the hanging man game! \nAnd I have choosen to use body parts as secret word. ;)");

            string secretWord = RandomBodyParts().ToUpper();
            Debug.Print(secretWord);
            StringBuilder badGuesses = new StringBuilder();
            bool keepGuessing = true;

            //Define and fill guessArray with underscore chars...
            char[] guessArray = new char[secretWord.Length];
            for (int i = 0; i <guessArray.Length; i++)
            {
                guessArray[i] = '_';
            }

            Console.WriteLine($"I'l help you out a little... the word is {secretWord.Length} letter long. Good luck :)");
            
            do {
                string strGuess = Console.ReadLine().ToUpper();

                //filter on word length, or first char in string only
                if (strGuess.Length != secretWord.Length) {
                    strGuess = strGuess.Substring(0);
                    Debug.Print(strGuess.Length.ToString());
                }

                //Loop for each char in User input.
                foreach (char Guess in strGuess)
                {
                    if (GuessRight(Guess, secretWord))
                    {
                        // God guess. Add char to guessArray at the correct place. Can be more than one occurrance/slot!
                        for (int i = 0; i < secretWord.Length; ++i)
                        {
                            if (Guess.Equals(secretWord[i]))
                            {
                                guessArray[i] = Guess;
                            }
                        }
                    }
                    else
                    {
                        //Bad guess: the letter to the badGuess Stringbuilder class. Letters only.
                        if (badGuesses.ToString().IndexOf(Guess) < 0 && Char.IsLetter(Guess)) {
                            badGuesses.Append(Guess + " ");
                        }
                    }
                }

                //Break when out of guesses = 10. String has additional whitespace = 20 chars
                if (badGuesses.Length > 20) break;
                PrintConsole(badGuesses, guessArray);

                //Break loop is array is filld ( = no underscores left) 
                if (!guessArray.Contains('_')) break;

            } while (keepGuessing);

            //Loop exited, decide game.
            WonOrLost(guessArray);
        }
        /// <summary>
        /// Test for game result and print to console..
        /// </summary>
        /// <param name="guessArray"></param>
        public static bool WonOrLost(char[] guessArray)
        {
            if (!guessArray.Contains('_'))
            {
                Console.WriteLine("Congrats, you won");
                return true;
            } else
            {
                Console.Beep();
                Console.WriteLine("Sorry, you lost :(");
                return false;
            }
        }
        /// <summary>
        /// Print both Char array and Stringbuilder to console
        /// </summary>
        /// <param name="bad"></param>
        /// <param name="correct"></param>
        static void PrintConsole(StringBuilder bad, char[] correct)
        {
            Console.Write("Current status: ");
            foreach (char c in correct)
            {
                Console.Write(c.ToString() + " ");
            }

            Console.WriteLine("  Bad guesses so far: " + bad.ToString());
        }
 
        /// <summary>
        /// Test for guess
        /// </summary>
        /// <param name="guess"></param>
        /// <param name="secretWord"></param>
        /// <returns></returns>
        public static bool GuessRight(char guess, string secretWord)
        {
            int test = secretWord.IndexOf(guess);
            if (test < 0)
            {
                return false;
            } 
            else
            {
                return true;
            }
        }
        public static string RandomBodyParts() {
            // The secret word should be randomly chosen from an array of Strings.

            // version 1:
            //string[] bodyparts = { "Tooth", "Foot", "Leg", "Back", "Brain", "Heart", "Waist", "Hip", "Arm", "Liver" };

            // option, version 1:
            string path = "RandomWords.txt";
            string readText = File.ReadAllText(path);
            string[] bodyparts = readText.Split(',');

            Random rnd = new Random();
            return bodyparts[rnd.Next(bodyparts.Length)];
        }
    }
}