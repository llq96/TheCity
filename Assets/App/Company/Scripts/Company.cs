using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace TheCity
{
    public class Company : MonoBehaviour
    {
        [Inject] private CompanyData CompanyData { get; }
        [Inject] public Room Room { get; }
        [Inject] public List<JobPost> JobPosts { get; }

        public override string ToString() => CompanyData.ToString();
    }
}