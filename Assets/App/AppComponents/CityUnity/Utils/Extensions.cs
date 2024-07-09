using UnityEngine;

namespace TheCity.Unity
{
    public static partial class Extensions
    {
        public static void SetPositionAndRotation(this Transform obj, Transform target)
        {
            obj.transform.SetPositionAndRotation(target.position, target.rotation);
        }
    }
}