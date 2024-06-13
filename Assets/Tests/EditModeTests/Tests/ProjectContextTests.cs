using System.Linq;
using Zenject;
using NUnit.Framework;
using TheCity.Tests.EditorUtils;
using TheCity.Tests.Utils;
using UnityEngine;

namespace TheCity.Tests
{
    [TestFixture]
    public class ProjectContextTests : ZenjectUnitTestFixture
    {
        [Inject] private ProjectContext ProjectContext { get; }

        [SetUp]
        public void SetUp()
        {
            var projectContextPrefab = ProjectContextAccessor.GetProjectContext();
            Container.Bind<ProjectContext>().FromInstance(projectContextPrefab).AsSingle().NonLazy();
            Container.Inject(this);
        }

        [Test]
        public void ProjectContext_ShouldExist()
        {
            Assert.NotNull(ProjectContext, "ProjectContext should exist at path Resources/ProjectContext");
        }

        [Test]
        public void ProjectContext_Installers_ShouldNotHave_NullFields()
        {
            var components = ProjectContext.GetComponents<Component>().ToList();
            if (ReflectionHelper.IsHaveEmptySerializableFields(components, out var tuple))
            {
                Assert.Fail($"Field {tuple.Item2} In {tuple.Item1} In Project Context Is Null");
            }
        }
    }
}