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
        public void CommonInstall()
        {
            Container.Bind<ProjectContext>().FromInstance(ProjectContextAccessor.GetProjectContext())
                .AsSingle().NonLazy();
            Container.Inject(this);
        }

        [Test]
        public void ProjectContextExistTest()
        {
            Assert.NotNull(ProjectContext);
        }

        [Test]
        public void ProjectContextInstallersDontHaveEmptySerializableFieldsTest()
        {
            var components = ProjectContext.GetComponents<Component>().ToList();
            if (ReflectionHelper.IsHaveEmptySerializableFields(components, out var tuple))
            {
                Assert.Fail($"Field {tuple.Item2} In {tuple.Item1} In Project Context Is Null");
            }
        }
    }
}