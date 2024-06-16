using System.Collections;
using System.Linq;
using NUnit.Framework;
using TheCity.Tests.Utils;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace TheCity.Tests.Bindings
{
    public class ZenjectBindingTests : ZenjectIntegrationTestFixture
    {
        [UnityTest]
        public IEnumerator ProjectContext_AfterPostInstall_ShouldBeBindingWithoutErrors()
        {
            SkipInstall();

            yield return null;

            var projectContext = Object.FindObjectOfType<ProjectContext>();
            Assert.NotNull(projectContext, "Project Context Should Be Binding Without Errors");
        }

        [UnityTest]
        public IEnumerator InstallersFields_AfterPostInstall_ShouldNotBeNull()
        {
            SkipInstall();

            yield return null;

            var projectContext = Object.FindObjectOfType<ProjectContext>();
            var components = projectContext.GetComponents<Component>().ToList();
            if (ReflectionHelper.IsHaveEmptySerializableFields(components, out var tuple))
            {
                Assert.Fail($"Field {tuple.Item2} In {tuple.Item1} In Project Context Is Null");
            }
        }
    }
}