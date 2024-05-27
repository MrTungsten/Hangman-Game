using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace HangmanGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            bool gameActive = false;

            Console.Title = "Hangman Game";
            Console.WriteLine("Welcome to Hangman!");

            HangmanGame hangmanGame = new HangmanGame();

            do
            {
                if (!gameActive)
                {
                    gameActive = true;
                    hangmanGame.ResetGame();
                    hangmanGame.Play();
                }

                Console.Write("Do you want to continue playing Hangman (Y/N)? ");
                switch (Console.ReadLine()?.ToUpper())
                {
                    case "Y":
                        isPlaying = true;
                        gameActive = false;
                        Console.Clear();
                        Console.WriteLine("Welcome to Hangman!");
                        break;
                    case "N":
                        isPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Please enter an acceptable answer.");
                        break;
                }
            } while (isPlaying);
        }
    }

    class HangmanGame
    {
        Random random = new Random();
        List<string> wordList = new List<string>()
        {
            "scythe",
            "apple",
            "osmosis",
            "laughing",
            "extend",
            "brown",
            "expert",
            "tired",
            "humidity",
            "backpack",
            "wares",
            "soup",
            "mount",
            "crust",
            "dent",
            "market",
            "knock",
            "smite",
            "windy",
            "coin",
            "throw",
            "silence",
            "bluff",
            "downfall",
            "mass",
            "game",
            "stocking",
            "folly",
            "action",
        };
        char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        string[] hangmanStages =
        {
    // final state: head, torso, both arms, and both legs
    @"
        --------
        |      |
        |      O
        |     \|/
        |      |
        |     / \
        -",
    // head, torso, both arms, and one leg
    @"
        --------
        |      |
        |      O
        |     \|/
        |      |
        |     / 
        -",
    // head, torso, and both arms
    @"
        --------
        |      |
        |      O
        |     \|/
        |      |
        |      
        -",
    // head, torso, and one arm
    @"
        --------
        |      |
        |      O
        |     \|
        |      |
        |     
        -",
    // head and torso
    @"
        --------
        |      |
        |      O
        |      |
        |      |
        |     
        -",
    // head
    @"
        --------
        |      |
        |      O
        |    
        |      
        |     
        -",
    // initial empty state
    @"
        --------
        |      |
        |      
        |    
        |      
        |     
        -",
        };

        private List<char> correctGuesses = new List<char>();
        private List<char> incorrectGuesses = new List<char>();
        private List<char> availableGuesses = new List<char>();
        private string? correctWord;
        private char[]? currentGuess;
        private string? input;
        private char inputChar;
        private const int maximumLives = 6;
        private int numOfLives;
        
        public void ResetGame()
        {
            correctGuesses = new List<char>();
            incorrectGuesses = new List<char>();
            availableGuesses = alphabet.ToList();
            correctWord = wordList[random.Next(0, wordList.Count)].ToUpper();
            currentGuess = new char[correctWord.Length];
            wordList.Remove(correctWord);
            numOfLives = maximumLives;

            for (int i = 0; i < correctWord.Length; i++)
            {
                if (correctWord[i] == ' ')
                {
                    currentGuess[i] = ' ';
                }
            }
        }

        public void Play()
        {
            DrawDisplay();
            while (correctWord != (new string(currentGuess)).ToUpper() && numOfLives > 0)
            {
                Console.Write("Please enter your guess: ");
                input = Console.ReadLine()?.ToUpper();

                if (String.Equals(input?.ToUpper(), correctWord))
                {
                    break;
                }

                if (input?.Length > 1)
                {
                    input = "$";
                }

                inputChar = Convert.ToChar(input);

                if (availableGuesses.Contains(inputChar))
                {
                    if (correctWord.Contains(inputChar))
                    {
                        for (int i = 0; i < correctWord.Length; i++)
                        {
                            if (correctWord[i] == inputChar)
                            {
                                currentGuess[i] = inputChar;
                                availableGuesses.Remove(inputChar);
                                correctGuesses.Add(inputChar);
                                Console.WriteLine("Added Char: " + inputChar);
                            }
                            else if (correctWord[i] == ' ')
                            {
                                currentGuess[i] = ' ';
                            }
                            else if (!(correctGuesses.Contains(correctWord[i])))
                            {
                                currentGuess[i] = '\0';
                            }
                        }
                    }
                    else
                    {
                        availableGuesses.Remove(inputChar);
                        incorrectGuesses.Add(inputChar);
                        numOfLives--;
                    }

                    DrawDisplay(true);
                }
                else if (correctGuesses.Contains(inputChar) || incorrectGuesses.Contains(inputChar))
                {
                    Console.WriteLine("You already entered that!");
                }
                else
                {
                    Console.WriteLine("Please enter an acceptable input.");
                }
            }

            Console.Clear();
            if (numOfLives > 0)
                Console.WriteLine($"Congratulations! You won with {numOfLives} {(numOfLives == 1 ? "life" : "lives")} left! "
                    + "The correct word was "
                    + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(correctWord.ToLower()));
            else
                Console.WriteLine("Sorry! You lost! The correct word was " +
                    CultureInfo.CurrentCulture.TextInfo.ToTitleCase(correctWord.ToLower()));
            currentGuess = correctWord.ToCharArray();
            DrawDisplay(false);
        }

        private void DisplayCharArray(char[] chars)
        {
            for (int i = (int) (8 - Math.Round((decimal) (chars.Length / 2), MidpointRounding.AwayFromZero)); i >= 0; i--)
            {
                Console.Write(" ");
            }

            foreach (char c in chars)
            {
                if (c == '\0')
                {
                    Console.Write("_ ");
                }
                else
                {
                    Console.Write(c + " ");
                }
            }

            Console.WriteLine("\n");
        }

        private void DrawDisplay(bool isGuessing = false)
        {
            if (isGuessing)
            {
                Console.Clear();
                if (correctWord.Contains(inputChar))
                    Console.WriteLine("That guess was correct!");
                else
                    Console.WriteLine("That guess was incorrect!");

                Console.Write("Incorrect Guesses: ");
                for (int i = 0; i < incorrectGuesses.Count; i++)
                {
                    Console.Write(incorrectGuesses[i] + " ");
                }
                Console.WriteLine($"\nYou have {numOfLives} {(numOfLives == 1 ? "life" : "lives")} left!");
            }

            Console.WriteLine(hangmanStages[numOfLives]);
            DisplayCharArray(currentGuess);
        }
    }

}