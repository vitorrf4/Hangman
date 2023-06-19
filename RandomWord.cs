﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace HangmanGame
{
    public class RandomWord
    {
        public static string getWord()
        {
            HttpClient client = new();
            var responseTask = client.GetAsync("https://random-word-frm.herokuapp.com/random/noun");
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
