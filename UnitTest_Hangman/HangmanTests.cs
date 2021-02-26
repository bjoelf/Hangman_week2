using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman_week2;
using System;


///https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019


namespace UnitTest_Hangman
{
    [TestClass]
    public class HangmanTests
    {
        [TestMethod]
        public void LostGame()
        {
            char[] guessArray = new char[3];
            for (int i = 0; i < guessArray.Length; i++)
            {
                guessArray[i] = '_';
            }
            Assert.IsFalse(Program.WonOrLost(guessArray));
        }

        [TestMethod]
        public void WonGame()
        {
            string secretWord = "";
            char[] guessArray = new char[secretWord.Length];
            for (int i = 0; i < guessArray.Length; i++)
            {
                guessArray[i] = 'A';
            }
            Assert.IsTrue(Program.WonOrLost(guessArray));
        }

        [TestMethod]
        public void GoodGuess()
        {
            string secretWord = "BRAIN";
            char guess = 'A';
            Assert.IsTrue(Program.GuessRight(guess,secretWord));
        }

        [TestMethod]
        public void BadGuess()
        {
            string secretWord = "BRAIN";
            char guess = 'X';
            Assert.IsFalse(Program.GuessRight(guess, secretWord));
        }

    }
}