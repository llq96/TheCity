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
                ""content"": ""Ты генератор мыслей внутри компьютерной игры, тебе нужно придумывать мысли исходя из контекста. Только одно предложение от первого лица. Используй информацию о названии компании, должности и расписания""
            },
            {
                ""role"": ""user"",
                ""content"": ""{0}""
            }
        ]
    }";

        private const string SkipWorkTemplate = @"{
        ""model"": ""gpt-4o-mini"",
        ""messages"": [
            {
                ""role"": ""system"",
                ""content"": ""Ты генератор мыслей внутри компьютерной игры, тебе нужно придумывать мысли исходя из контекста. Только одно предложение от первого лица. Используй информацию о названии компании, должности и расписания. Тебе нужно решить работать сегодня или нет. Начни ответ либо со слова Да, либо со слова Нет. Если Да - придумай почему ты хочешь пропустить работу. Если Нет - придумай почему работа сегодня важна. Вероятность пропуска работы равна 50 процентам""
            },
            {
                ""role"": ""user"",
                ""content"": ""{0}""
            }
        ]
    }";

        public async Task<string> GenerateThink(string context)
        {
#if EXIST_AI
            return await AIChat.GetAnswer(QuestionTemplate, context);
#endif
            return "Скучно...";
        }

        public async Task<string> GenerateThinkAboutSkipWork(string context)
        {
#if EXIST_AI
            return await AIChat.GetAnswer(SkipWorkTemplate, context);
#endif
            return "Нет, нельзя отдыхать, надо работать...";
        }
    }
}