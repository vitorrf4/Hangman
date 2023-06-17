namespace HangmanGame
{
    class Hangman
    {
        static void Main()
        {
            Game game = new("computer");
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

            //TODO: validate special characters
        }
    }
}

