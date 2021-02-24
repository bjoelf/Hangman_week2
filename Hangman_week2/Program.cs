using System;
using System.Diagnostics;
using System.Text;

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
            Console.WriteLine($"Hello dear user, time to play the handing man game! \nAnd I have choosen to use body parts as secret word. \nWicked huuh! ;)");

            string secretWord = RandomBodyParts().ToUpper();
            Debug.Print(secretWord);
            char[] guessArray = new char[secretWord.Length];
            StringBuilder badGuesses = new StringBuilder();
            bool keepGuessing = true;

            //fill guessArray with underscore chars...
            for (int i = 0; i <guessArray.Length; i++)
            {
                guessArray[i] = '_';
            }

            Console.WriteLine($"I'l help you out a little... the word is {secretWord.Length.ToString()} letter long. Good luck :)");
            do {
                char Guess = char.Parse(Console.ReadLine().ToUpper());
                if (GuessRight(Guess, secretWord))
                { //correct guess...


                    // add char to guessArray (at the correct place..!)


                }
                else 
                {
                    //bad guess
                    //The incorrect letters the player has guessed, should be put inside a StringBuilder and presented to the playe
                    badGuesses.Append(Guess + " ");
                    break;
                }
                PrintConsole(badGuesses, guessArray);
            } while (keepGuessing);

            //decide here if game in won or lost.
            WonOrLost(guessArray);
        }

        static void WonOrLost(char[] correct)
        {
            if (true)
            {
                //Message
            } else
            {
                //Message
            }
        }

        static void PrintConsole(StringBuilder bad, char[] correct)
        {
            Console.Write(bad.ToString());
            foreach (char c in correct)
            {
                Console.Write(c.ToString() + " ");

            }
        }
        static bool GuessRight(char guess, string secretWord)
        {
            int test = secretWord.IndexOf(guess);
            
            bool ret = false;


            //loopa en matchning, om match stoppa in bokstaven i char arrayen på rätt plats.


            return ret;
        }

        /// The secret word should be randomly chosen from an array of Strings.
        static string RandomBodyParts()
        {
            string[] bodyparts = { "Tooth", "Foot", "Leg", "Back", "Brain", "Heart", "Waist", "Hip", "Arm", "Liver" };
            return bodyparts[rnd.Next(bodyparts.Length)];
        }
    }
}
