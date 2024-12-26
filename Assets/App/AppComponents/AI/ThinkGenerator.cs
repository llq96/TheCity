using System.Threading.Tasks;

namespace TheCity.AI
{
    public class ThinkGenerator
    {
        private const string QuestionTemplate = @"{
        ""model"": ""gpt-4o-mini"",
        ""messages"": [
            {
                ""role"": ""system"",
                ""content"": ""Ты генератор мыслей внутри компьютерной игры, тебе нужно придумывать мысли исходя из контекста. Только одно предложение от первого лица""
            },
            {
                ""role"": ""user"",
                ""content"": ""{0}""
            }
        ]
    }";

        public async Task<string> GenerateThink(string context)
        {
            // return await AIChat.GetAnswer(context);
            return await AIChat.GetAnswer(QuestionTemplate, context);
        }
    }
}