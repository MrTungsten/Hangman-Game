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
            "Scythe",
            "Apple",
            "Osmosis",
            "Laughing",
            "wares",
            "soup",
            "mount",
            "extend",
            "brown",
            "expert",
            "tired",
            "humidity",
            "backpack",
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
            "climb",
            "lying",
            "weaver",
            "snob",
            "kickoff",
            "match",
            "quaker",
            "foreman",
            "excite",
            "thinking",
            "mend",
            "allergen",
            "pruning",
            "coat",
            "emerald",
            "coherent",
            "manic",
            "multiple",
            "square",
            "funded",
            "funnel",
            "sailing",
            "dream",
            "mutation",
            "strict",
            "mystic",
            "film",
            "guide",
            "strain",
            "bishop",
            "settle",
            "plateau",
            "emigrate",
            "marching",
            "optimal",
            "medley",
            "endanger",
            "wick",
            "condone",
            "schema",
            "rage",
            "figure",
            "plague",
            "aloof",
            "there",
            "reusable",
            "refinery",
            "suffer",
            "affirm",
            "captive",
            "flipping",
            "prolong",
            "main",
            "coral",
            "dinner",
            "rabbit",
            "chill",
            "seed",
            "born",
            "shampoo",
            "italian",
            "giggle",
            "roost",
            "palm",
            "globe",
            "wise",
            "grandson",
            "running",
            "sunlight",
            "spending",
            "crunch",
            "tangle",
            "forego",
            "tailor",
            "divinity",
            "probe",
            "bearded",
            "premium",
            "featured",
            "serve",
            "borrower",
            "examine",
            "legal",
            "outlive",
            "unnamed",
            "unending",
            "snow",
            "whisper",
            "bundle",
            "bracket",
            "deny",
            "blurred",
            "pentagon",
            "reformed",
            "polarity",
            "jumping",
            "gain",
            "laundry",
            "hobble",
            "culture",
            "whittle",
            "docket",
            "mayhem",
            "build",
            "peel",
            "board",
            "keen",
            "glorious",
            "singular",
            "cavalry",
            "present",
            "cold",
            "hook",
            "salted",
            "just",
            "dumpling",
            "glimmer",
            "drowning",
            "admiral",
            "sketch",
            "subject",
            "upright",
            "sunshine",
            "slide",
            "calamity",
            "gurney",
            "adult",
            "adore",
            "weld",
            "masking",
            "print",
            "wishful",
            "foyer",
            "tofu",
            "machete",
            "diced",
            "behemoth",
            "rout",
            "midwife",
            "neglect",
            "mass",
            "game",
            "stocking",
            "folly",
            "action",
            "bubbling",
            "scented",
            "sprinter",
            "bingo",
            "egyptian",
            "comedy",
            "rung",
            "outdated",
            "radical",
            "escalate",
            "mutter",
            "desert",
            "memento",
            "kayak",
            "talon",
            "portion",
            "affirm",
            "dashing",
            "fare",
            "battle",
            "pupil",
            "rite",
            "smash",
            "true",
            "entrance",
            "counting",
            "peruse",
            "dioxide",
            "hermit",
            "carving",
            "backyard",
            "homeless",
            "medley",
            "packet",
            "tickle",
            "coming",
            "leave",
            "swing",
            "thicket",
            "reserve",
            "murder",
            "costly",
            "corduroy",
            "bump",
            "oncology",
            "swatch",
            "rundown",
            "steal",
            "teller",
            "cable",
            "oily",
            "official",
            "abyss",
            "schism",
            "failing",
            "guru",
            "trim",
            "alfalfa",
            "doubt",
            "booming",
            "bruised",
            "playful",
            "kicker",
            "jockey",
            "handmade",
            "landfall",
            "rhythm",
            "keep",
            "reassure",
            "garland",
            "sauna",
            "idiom",
            "fluent",
            "lope",
            "gland",
            "amend",
            "fashion",
            "treaty",
            "standing",
            "current",
            "sharpen",
            "cinder",
            "idealist",
            "festive",
            "frame",
            "molten",
            "sill",
            "glisten",
            "fearful",
            "basement",
            "minutia",
            "coin",
            "stick",
            "featured",
            "soot",
            "static",
            "crazed",
            "upset",
            "robotics",
            "dwarf",
            "shield",
            "butler",
            "stitch",
            "stub",
            "sabotage",
            "parlor",
            "prompt",
            "heady",
            "horn",
            "bygone",
            "rework",
            "painful",
            "composer",
            "glance",
            "acquit",
            "eagle",
            "solvent",
            "backbone",
            "smart",
            "atlas",
            "leap",
            "danger",
            "bruise",
            "seminar",
            "tinge",
            "trip",
            "narrow",
            "while",
            "jaguar",
            "seminary",
            "command",
            "cassette",
            "draw",
            "anchovy",
            "scream",
            "blush",
            "organic",
            "applause",
            "parallel",
            "trolley",
            "pathos",
            "origin",
            "hang",
            "pungent",
            "angular",
            "stubble",
            "painted",
            "forward",
            "saddle",
            "muddy",
            "orchid",
            "prudence",
            "disprove",
            "yiddish",
            "lobbying",
            "neuron",
            "tumor",
            "haitian",
            "swift",
            "mantel",
            "wardrobe",
            "consist",
            "storied",
            "extreme",
            "payback",
            "control",
            "dummy",
            "influx",
            "realtor",
            "detach",
            "flake",
            "consign",
            "adjunct",
            "stylized",
            "weep",
            "prepare",
            "pioneer",
            "tail",
            "platoon",
            "exercise",
            "dummy",
            "clap",
            "actor",
            "spark",
            "dope",
            "phrase",
            "welsh",
            "wall",
            "whine",
            "fickle",
            "wrong",
            "stamina",
            "dazed",
            "cramp",
            "filet",
            "foresee",
            "seller",
            "award",
            "mare",
            "uncover",
            "drowning",
            "ease",
            "buttery",
            "luxury",
            "bigotry",
            "muddy",
            "photon",
            "snow",
            "oppress",
            "blessed",
            "call",
            "stain",
            "amber",
            "rental",
            "nominee",
            "township",
            "adhesive",
            "lengthy",
            "swarm",
            "court",
            "baguette",
            "leper",
            "vital",
            "push",
            "digger",
            "setback",
            "accused",
            "taker",
            "genie",
            "reverse",
            "fake",
            "widowed",
            "renewed",
            "goodness",
            "featured",
            "curse",
            "shocked",
            "shove",
            "marked",
            "interact",
            "mane",
            "hawk",
            "kidnap",
            "noble",
            "proton",
            "effort",
            "patriot",
            "showcase",
            "parish",
            "mosaic",
            "coil",
            "aide",
            "breeder",
            "concoct",
            "pathway",
            "hearing",
            "bayou",
            "regimen",
            "drain",
            "bereft",
            "matte",
            "bill",
            "medal",
            "prickly",
            "sarcasm",
            "stuffy",
            "allege",
            "monopoly",
            "lighter",
            "repair",
            "worship",
            "vent",
            "hybrid",
            "buffet",
            "lively",
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
                    -
                ",
            // head, torso, both arms, and one leg
            @"
                    --------
                    |      |
                    |      O
                    |     \|/
                    |      |
                    |     / 
                    -
                ",
            // head, torso, and both arms
            @"
                    --------
                    |      |
                    |      O
                    |     \|/
                    |      |
                    |      
                    -
                ",
            // head, torso, and one arm
            @"
                    --------
                    |      |
                    |      O
                    |     \|
                    |      |
                    |     
                    -
                ",
            // head and torso
            @"
                    --------
                    |      |
                    |      O
                    |      |
                    |      |
                    |     
                    -
                ",
            // head
            @"
                    --------
                    |      |
                    |      O
                    |    
                    |      
                    |     
                    -
                ",
            // initial empty state
            @"
                    --------
                    |      |
                    |      
                    |    
                    |      
                    |     
                    -
                ",
        };

        private List<char> correctGuesses = new List<char>();
        private List<char> incorrectGuesses = new List<char>();
        private List<char> availableGuesses = new List<char>();
        private string? correctWord;
        private char[]? currentGuess;
        private string? input;
        private char inputChar;
        private int numOfLives = 6;
        
        public void ResetGame()
        {
            correctWord = wordList[random.Next(0, wordList.Count)].ToUpper();
            wordList.Remove(correctWord);
            currentGuess = new char[correctWord.Length];
            availableGuesses = alphabet.ToList();
            correctWord.Replace(' ', '#');
            numOfLives = 6;

            for (int i = 0; i < correctWord.Length; i++)
            {
                if (correctWord[i] == ' ')
                {
                    currentGuess[i] = '#';
                }
                else
                {
                    currentGuess[i] = ' ';
                }
            }
        }

        public void Play()
        {
            DrawDisplay(true);
            while (correctWord != (new string(currentGuess)).Replace('#', ' ').ToUpper() && numOfLives > 0)
            {
                Console.Write("Please enter your guess: ");
                input = Console.ReadLine();

                if (String.Equals(input.ToUpper(), correctWord.Replace('#', ' ')))
                {
                    break;
                }

                try
                {
                    Convert.ToChar(input);
                }
                catch
                {
                    Console.WriteLine("Please enter an acceptable input.");
                    input = "$";
                }

                input = input.ToUpper();
                inputChar = Convert.ToChar(input);

                if (availableGuesses.Contains(inputChar) && inputChar != '$')
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
                                currentGuess[i] = '#';
                            }
                            else if (!(correctGuesses.Contains(correctWord[i])) || currentGuess[i] == '\0')
                            {
                                currentGuess[i] = ' ';
                            }
                        }
                    }
                    else
                    {
                        availableGuesses.Remove(inputChar);
                        incorrectGuesses.Add(inputChar);
                        numOfLives--;
                    }

                    DrawDisplay();
                }
                else if (inputChar == ' ')
                {
                    Console.WriteLine("Please enter an acceptable input.");
                }
                else if (correctGuesses.Contains(inputChar) || incorrectGuesses.Contains(inputChar))
                {
                    Console.WriteLine("You already entered that!");
                }
            }

            if (numOfLives > 0)
                Console.WriteLine($"Congratulations! You won with {numOfLives} {(numOfLives == 1 ? "life" : "lives")} left! "
                    + "The correct word was "
                    + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(correctWord.Replace('#', ' ').ToLower()));
            else
                Console.WriteLine("Sorry! You lost! The correct word was " +
                    CultureInfo.CurrentCulture.TextInfo.ToTitleCase(correctWord.Replace('#', ' ').ToLower()));
        }

        private void DisplayCharArray(char[] chars)
        {
            foreach (char c in chars)
            {
                if (c == ' ')
                {
                    Console.Write("_ ");
                }
                else if (c == '#')
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(c + " ");
                }
            }

            Console.WriteLine("");
        }

        private void DrawDisplay(bool firstTime = false)
        {
            if (!firstTime)
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
                Console.WriteLine("\n");
            }
            
            Console.WriteLine(hangmanStages[numOfLives]);
            DisplayCharArray(currentGuess);
        }
    }

}