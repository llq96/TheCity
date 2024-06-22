using System.Collections.Generic;

namespace TheCity.Installers.Utils
{
    public static partial class Extensions
    {
        // private static Random Random { get; } = new();

        public static void Shuffle<T>(this IList<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int rnd = Random.Range(0, list.Count);
                (list[i], list[rnd]) = (list[rnd], list[i]);
            }
        }

        public static List<T> GetShuffledCopy<T>(this IEnumerable<T> list)
        {
            var copy = new List<T>(list);
            copy.Shuffle();
            return copy;
        }
    }
}