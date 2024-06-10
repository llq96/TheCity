using System.Collections.Generic;
using UnityEngine;

namespace TheCity
{
    public static partial class Extensions
    {
        public static T GetRandomElement<T>(this IList<T> list)
        {
            var randomIndex = Random.Range(0, list.Count);
            return list[randomIndex];
        }
    }
}