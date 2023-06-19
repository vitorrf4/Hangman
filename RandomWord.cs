using System.Text.RegularExpressions;

namespace HangmanGame
{
    public class RandomWord
    {
        public static string GetWord()
        {
            HttpClient client = new();
            var responseTask = client.GetAsync("https://random-word-form.herokuapp.com/random/noun");
            responseTask.Wait();

            if (!(responseTask.Result.IsSuccessStatusCode))
            {
                throw new Exception("The application could not run: " + responseTask.Result.StatusCode);
            }

            var stringResponse = responseTask.Result.Content.ReadAsStringAsync();
            stringResponse.Wait();
            var jsonWord = stringResponse.Result;

            jsonWord = Regex.Replace(jsonWord, "[\\[\\]\"]" , "");
            return jsonWord;
        }
    }
}
