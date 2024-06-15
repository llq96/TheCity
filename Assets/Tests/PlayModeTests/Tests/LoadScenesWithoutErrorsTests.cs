using Zenject;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace TheCity.Tests.SceneLoadingTests
{
    [ExcludeFromCoverage]
    public class LoadScenesWithoutErrorsTests : SceneTestFixture
    {
        public IEnumerator LoadScene_Main_WithoutErrors()
        {
            yield return LoadScene("Main");

            yield return new WaitForSeconds(2.0f);
        }
    }
}