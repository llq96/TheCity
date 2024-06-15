using Zenject;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace TheCity.Tests.SceneLoadingTests
{
    [TestFixture(IgnoreReason = "Exclude Code Coverage Dont Work")]
    public class LoadScenesWithoutErrorsTests : SceneTestFixture
    {
        [UnityTest]
        public IEnumerator LoadScene_Main_WithoutErrors()
        {
            yield return LoadScene("Main");

            yield return new WaitForSeconds(2.0f);
        }
    }
}