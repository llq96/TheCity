using System.Collections.Generic;
using UnityEngine;

namespace TheCity.Unity
{
    public class House : MonoBehaviour
    {
        [field:SerializeField] public List<Transform> SpawnPoints { get; private set; }
    }
}
