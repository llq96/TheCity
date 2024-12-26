using TheCity.AI;
using UniRx;
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
            // Debug.Log(think);
            LastThink.Value = think;
        }
    }
}