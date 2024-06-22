using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheCity
{
    public static partial class Extensions
    {
        private static Random Random { get; } = new();

        public static T GetRandomElement<T>(this IList<T> list)
        {
            var randomIndex = Random.Next(0, list.Count);
            return list[randomIndex];
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