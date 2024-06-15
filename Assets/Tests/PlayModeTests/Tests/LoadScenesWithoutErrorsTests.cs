using Zenject;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace TheCity.Tests.SceneLoadingTests
{
    public class LoadScenesWithoutErrorsTests : SceneTestFixture
    {
        [UnityTest, ExcludeFromCoverage]
        public IEnumerator LoadScene_Main_WithoutErrors()
        {
            yield return LoadScene("Main");

            yield return new WaitForSeconds(2.0f);
        }
    }
}