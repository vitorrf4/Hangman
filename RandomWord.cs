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

            var result = responseTask.Result;
            var readTask = result.Content.ReadAsStringAsync();
            readTask.Wait();
            var word = readTask.Result;
            word = word.Replace("[", "");
            word = word.Replace("]", "");
            word = word.Replace("\"", "");
            word = word.Replace("]", "");
            return word;
        }
    }
}
