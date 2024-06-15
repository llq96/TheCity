using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace TheCity.Tests.Bindings
{
    public class ZenjectBindingTests : ZenjectIntegrationTestFixture
    {
        [UnityTest]
        public IEnumerator ProjectContext_ShouldBeBinding_WithoutErrors()
        {
            SkipInstall();

            yield return null;

            var projectContext = Object.FindObjectOfType<ProjectContext>();
            Assert.NotNull(projectContext, "Project Context Should Be Binding Without Errors");
        }
    }
}