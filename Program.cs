namespace HangmanGame
{
    class Hangman
    {
        static void Main()
        {
            do
            {
                string word = RandomWord.GetWord();
                Game game = new(word);

                if (word.Length > 0)
                {
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
                }
            } while (Game.PromptReplay());
            
            //TODO: Validate special characters
            //TODO: Filter random words with special characters
        }
    }
}

