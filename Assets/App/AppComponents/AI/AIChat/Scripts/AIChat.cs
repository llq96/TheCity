#if EXIST_AI
using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TheCity.AI
{
    public static class AIChat
    {
        private const string DefaultTemplate = @"{
        ""model"": ""gpt-4o-mini"",
        ""messages"": [
            {
                ""role"": ""system"",
                ""content"": ""You are a helpful assistant.""
            },
            {
                ""role"": ""user"",
                ""content"": ""{0}""
            }
        ]
    }";

        public static async Task<string> GetAnswer(string question)
        {
            return await GetAnswer(DefaultTemplate, question);
        }

        public static async Task<string> GetAnswer(string template, string question)
        {
            question = new string(question.Where(c => char.IsLetterOrDigit(c) || c == ' ').ToArray());
            string jsonContent = template.Replace("{0}", question);

            var httpClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.proxyapi.ru/openai/v1/chat/completions"),
                Headers =
                {
                    { HttpRequestHeader.ContentType.ToString(), "application/json" },
                    { HttpRequestHeader.Authorization.ToString(), "Bearer " + Secrets.API_KEY },
                },
                Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
            };

            var response = await httpClient.SendAsync(request);
            string answer = await GetClearAnswerFromResponse(response);

            return answer;
        }

        private static async Task<string> GetClearAnswerFromResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var parsedResponse = JObject.Parse(responseContent);

                var choices = parsedResponse["choices"];
                if (choices == null) return "*** 1";
                if (choices.Count() == 0) return "*** 2";
                if (choices[0] == null) return "*** 3";
                var message = choices![0]!["message"];
                if (message == null) return "*** 4";
                if (message["content"] == null) return "*** 5";
                var answer = message["content"]!.ToString();

                return answer;
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            return $"Error: {response.StatusCode}, Content: {errorContent}";
        }
    }
}
#endif