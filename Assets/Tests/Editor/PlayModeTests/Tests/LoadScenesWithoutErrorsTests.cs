using Zenject;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace TheCity.Tests
{
    public class LoadScenesWithoutErrorsTests : SceneTestFixture
    {
        [UnityTest]
        public IEnumerator LoadMainSceneWithoutErrors()
        {
            yield return LoadScene("Main");

            yield return new WaitForSeconds(2.0f);
        }
    }
}