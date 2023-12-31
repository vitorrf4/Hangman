﻿using System.Text.RegularExpressions;

namespace HangmanGame
{
    internal class Game
    {
        private string _guessedLetter;
        private readonly List<string> _guessedLetters = new(28);
        private readonly string _hangmanWord;
        public string[] WordUnderline { get; private set; }
        public int Attempts { get; private set; }

        public Game(string hangmanWord)
        {
            this._hangmanWord = hangmanWord;
            WordUnderline = new string[_hangmanWord.Length];

            for (int i = 0; i < _hangmanWord.Length; i++)
            {
                this.WordUnderline[i] = "_";
            }
        }

        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("   HANGMAN");
            DrawHangman();
            ShowUnderline();
        }

        public void DrawHangman()
        {
            string[] hangmanDrawing = { "", "", " ", "", "", "" };
            string[] hangmanParts = { "O", "|", "/", "\\", "/", "\\" };

            for (int i = 0; i < Attempts; i++)
            {
                hangmanDrawing[i] = hangmanParts[i];
            }
            Console.WriteLine(
            "_______________\n" +
            "|     |\n" +
            "|     |\n" +
            "|     {0}\n" +
            "|    {2}{1}{3}\n" +
            "|    {4} {5}\n", hangmanDrawing[0], hangmanDrawing[1], hangmanDrawing[2], hangmanDrawing[3], hangmanDrawing[4], hangmanDrawing[5]
            );
        }

        public void ShowUnderline()
        {
            for (int i = 0; i < WordUnderline.Length; i++)
            {
                Console.Write(WordUnderline[i].ToUpper() + " ");
            }
            Console.WriteLine("\n");
        }

        public void ShowGuessedLetters()
        {
            if (_guessedLetters.Count > 0)
            {
                Console.Write("Guessed Letters: ");
                foreach (string letter in _guessedLetters)
                {
                    Console.Write(letter.ToUpper() + " | ");
                }
                Console.WriteLine("\n");
            }
        }

        public void GetLetter()
        {
            Console.Write("Input a letter: ");
            _guessedLetter = Console.ReadLine().ToLower().Trim();
        }

        public bool ValidateLetter()
        {
            Regex specialCharacters = new ("[!@#$%&*()\\[\\]\\-=_+{}'\"\\|,.;/~^´`¨?¹²³£¢¬]");

            if (_guessedLetter.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("Guess at least one letter!");
                return false;
            }

            if (Char.IsDigit(_guessedLetter[0]))
            {
                Console.Clear();
                Console.WriteLine("No numbers allowed!");
                return false;
            }

            if (specialCharacters.IsMatch(_guessedLetter))
            {
                Console.Clear();
                Console.WriteLine("No special characters allowed!");
                return false;
            }

            if (_guessedLetter.Length > 1)
            {
                Console.Clear();
                Console.WriteLine("Guess just one letter!");
                return false;
            } 

            if (_guessedLetters.Contains(_guessedLetter))
            {
                Console.Clear();
                Console.WriteLine("You have already guessed this letter");
                return false;
            }

            return true;
        }

        public void CheckLetter()
        {
            if (_hangmanWord.Contains(_guessedLetter))
            {
                Console.Clear();
                Console.WriteLine("Right guess!");
                _guessedLetters.Add(_guessedLetter);

                for (int i = 0; i < _hangmanWord.Length; i++)
                {
                    if (_hangmanWord[i] == _guessedLetter[0])
                    {
                        WordUnderline[i] = _guessedLetter;
                    }
                }
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Wrong guess!");
                Attempts++;
                _guessedLetters.Add(_guessedLetter);
            }
        }

        public void CheckVictoryOrDefeat()
        {
            if (Attempts == 6)
            {
                Console.WriteLine($"GAME OVER\nThe word was {_hangmanWord}");
            }
            else
            {
                Console.WriteLine($"Congratulations, the word was {_hangmanWord}!");
            }
        }

        public static bool PromptReplay()
        {
            string response;
            bool replay = false;

            Console.WriteLine("Do you wish to play again?");
            Console.WriteLine("Type Y for Yes and N for no");

            do
            {
                response = Console.ReadLine().ToUpper();

                if (response == "Y")
                {
                    replay = true;
                }
                else if (response == "N")
                {
                    Console.WriteLine("Thanks for playing!");
                    replay = false;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("Type Y for Yes and N for no");
                }
            } while (!(response == "Y" || response == "N"));

            return replay;
        }
    }
}
