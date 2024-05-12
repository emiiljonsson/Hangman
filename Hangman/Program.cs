using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace HangmanApp
{
    internal class Program
    {
        private static void PrintHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("   ===");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine(" |     |");
                Console.WriteLine("     |");
                Console.WriteLine("    ===");
            }
            else if (wrong == 7)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|   |");
                Console.WriteLine("     |");
                Console.WriteLine("    ===");
            }
            else if (wrong == 8)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("     |");
                Console.WriteLine("    ===");
            }
            else if (wrong == 9)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/    |");
                Console.WriteLine("    ===");
            }
            else if (wrong == 10)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("    ===");
            }
        }

        private static int PrintWord(List<char> guessedLetters, string randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters += 1;
                }
                else
                {
                    Console.Write("_ ");
                }
                counter += 1;
            }
            return rightLetters;
        }

        private static void PrintLines(string randomWord)
        {
            Console.Write("\r");
            foreach (char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        private static bool GuessWholeWord(string randomWord, string guess)
        {
            return guess.ToLower() == randomWord.ToLower();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hangman :)");
            Console.WriteLine("-----------------------------------------");

            Random random = new Random();
            List<string> wordDictionary = new List<string> { "realmadrid", "coffee", "airpods" };

            int index = random.Next(wordDictionary.Count);
            string randomWord = wordDictionary[index];

            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;
            bool wordGuessed = false;

            while (amountOfTimesWrong != 10 && !wordGuessed)
            {
                Console.Write("\nLetters guessed so far is: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }

                Console.Write("\nGuess a letter or the whole word: ");
                string input = Console.ReadLine().ToLower();

                if (input.Length == 1)
                {
                    char letterGuessed = input[0];

                    if (currentLettersGuessed.Contains(letterGuessed))
                    {
                        Console.WriteLine("\nYou have already guessed this letter.");
                    }
                    else
                    {
                        bool right = false;
                        for (int i = 0; i < randomWord.Length; i++)
                        {
                            if (letterGuessed == randomWord[i])
                            {
                                right = true;
                            }
                        }

                        if (right)
                        {
                            currentLettersGuessed.Add(letterGuessed);
                            Console.WriteLine("\nCorrect guess!");
                        }
                        else
                        {
                            amountOfTimesWrong += 1;
                            Console.WriteLine("\nIncorrect guess.");
                        }
                    }
                }
                else // Om användaren gissade hela ordet
                {
                    wordGuessed = GuessWholeWord(randomWord, input);
                    if (wordGuessed)
                    {
                        Console.WriteLine("\nCongratulations! You guessed the word correctly!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect guess for the whole word.");
                    }
                }

                PrintHangman(amountOfTimesWrong);
                currentLettersRight = PrintWord(currentLettersGuessed, randomWord);
                Console.Write("\r\n");
                PrintLines(randomWord);
            }

            if (!wordGuessed)
            {
                Console.WriteLine("\nGame is over! The word was: " + randomWord);
            }
            Console.WriteLine("\nBYE");
        }
    }
}