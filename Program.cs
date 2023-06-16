namespace HangmanGame
{
    class Hangman
    {
        static void Main()
        {
            Game game = new("brewery");
            game.StartGame();
            game.DrawHangman();
            game.ShowUnderline();

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

            //TODO: validate special characters
        }
    }
}

