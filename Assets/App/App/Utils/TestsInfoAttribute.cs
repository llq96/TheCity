using System;
using UnityEngine.TestTools;

namespace TheCity
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
    [ExcludeFromCoverage]
    public class TestsInfoAttribute : Attribute
    {
        public TestsInfoAttribute(string testsClass, int lastCoverage)
        {
        }

        public TestsInfoAttribute(int lastCoverage)
        {
        }

        public TestsInfoAttribute(string testsClass)
        {
        }
    }
}