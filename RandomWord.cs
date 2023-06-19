using System.Text.RegularExpressions;

namespace HangmanGame
{
    public class RandomWord
    {
        public static string GetWord()
        {
            string jsonWord;

            do 
            {
                jsonWord = GenerateWord();
            } 
            while (jsonWord.Contains('-')); // generates another word if it's a hyphenated noun

            string formattedJson = FormatJson(jsonWord);
            return formattedJson;
        }
        public static string GenerateWord()
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
            var json = stringResponse.Result;

            return json;
        }
        public  static string FormatJson(string json)
        {
            string formattedJson = Regex.Replace(json, "[\\[\\]\"]", "");
            return formattedJson;
        }
    }
}
