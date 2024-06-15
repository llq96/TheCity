using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Random = UnityEngine.Random;

namespace TheCity
{
    public static partial class Extensions
    {
        public static T GetRandomElement<T>(this IList<T> list)
        {
            var randomIndex = Random.Range(0, list.Count);
            return list[randomIndex];
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int rnd = Random.Range(0, list.Count);
                (list[i], list[rnd]) = (list[rnd], list[i]);
            }
        }

        public static List<T> GetShuffledCopy<T>(this IList<T> list)
        {
            var copy = new List<T>(list);
            copy.Shuffle();
            return copy;
        }

        #region StringBuilder

        public static void AppendWithIndent(this StringBuilder stringBuilder, string text, int indentTabs)
        {
            var indent = new string('\t', indentTabs);
            var lines = text.Split(Environment.NewLine).ToList();
            var linesWithIndents = lines.Select(x => indent + x);
            stringBuilder.AppendJoin(Environment.NewLine, linesWithIndents);
        }

        public static void AppendWithIndent(this StringBuilder stringBuilder, object obj, int indentTabs)
        {
            stringBuilder.AppendWithIndent(obj.ToString(), indentTabs);
        }

        public static void AppendLineWithIndent(this StringBuilder stringBuilder, object obj, int indentTabs)
        {
            stringBuilder.AppendWithIndent(obj, indentTabs);
            stringBuilder.Append(Environment.NewLine);
        }

        public static void AppendLine(this StringBuilder stringBuilder, object obj)
        {
            stringBuilder.AppendLine(obj.ToString());
        }

        #endregion
    }
}