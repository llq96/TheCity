using System.Threading.Tasks;
using TheCity.AI;
using UniRx;
using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    public class CitizenThinker
    {
        [Inject] private Citizen Citizen { get; }
        [Inject] private GameTime GameTime { get; }
        [Inject] private ThinkGenerator ThinkGenerator { get; }


        public ReactiveProperty<string> LastThink { get; } = new();

        public async void ThinkAboutIt(string additionalContext)
        {
            var context = Citizen.GetFormattedInfo();
            context += $"\n Сейчас {GameTime.GameDateTime.Value.Date.ToString("dd/MM/yyyy HH:mm")}";
            context += $"\n {additionalContext}";
            var think = await ThinkGenerator.GenerateThink(context);
            LastThink.Value = think;
        }

        public async Task<bool> SkipWorkMaybe()
        {
            var context = Citizen.GetFormattedInfo();
            context += $"\n Сейчас {GameTime.GameDateTime.Value.Date.ToString("dd/MM/yyyy HH:mm")}";
            var think = await ThinkGenerator.GenerateThinkAboutSkipWork(context);

            LastThink.Value = think;
            if (think.StartsWith("Да"))
            {
                return true;
            }
            else if (think.StartsWith("Нет"))
            {
                return false;
            }

            Debug.LogError("Wrong AI answer");
            return false;
        }
    }
}