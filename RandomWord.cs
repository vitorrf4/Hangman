namespace HangmanGame
{
    public class RandomWord
    {
        public static string getWord()
        {
            HttpClient client = new();
            var responseTask = client.GetAsync("https://random-word-form.herokuapp.com/random/noun");
            responseTask.Wait();

            if (!(responseTask.Result.IsSuccessStatusCode))
            {
                throw new Exception("The application could not run: " + responseTask.Result.StatusCode);
            }

            var result = responseTask.Result.Content.ReadAsStringAsync();
            result.Wait();
            var word = result.Result;

            word = word.Replace("[", "");
            word = word.Replace("]", "");
            word = word.Replace("\"", "");
            word = word.Replace("]", "");
            return word;
        }
    }
}
