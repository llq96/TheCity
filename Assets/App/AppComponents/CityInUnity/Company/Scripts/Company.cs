using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TheCity
{
    public class Company : MonoBehaviour
    {
        [Inject] public CompanyData CompanyData { get; }
        [Inject] public WorkRoom Room { get; }
        [Inject] public List<JobPost> JobPosts { get; }

        public override string ToString() => CompanyData.ToString();
    }
}