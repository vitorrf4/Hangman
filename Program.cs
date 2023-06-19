using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace HangmanGame
{
    class Hangman
    {
        static void Main()
        {
            string word = RandomWord.getWord();

            if (word.Length > 0)
            {
                Game game = new(word);
                game.StartGame();

                while (game.Attempts < 6 && game.WordUnderline.Contains("_"))
                {
                    game.GetLetter();
                    if (game.ValidateLetter())
                        game.CheckLetter();
                    game.DrawHangman();
                    game.ShowUnderline();
                    game.ShowGuessedLetters();
                }

                game.CheckVictoryOrDefeat();
                Console.ReadKey();

            }

            //TODO: Validate special characters
            //TODO: Replay feature
            //TODO: Filter random words with special characters
        }
    }
}

