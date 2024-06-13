using Zenject;
using NUnit.Framework;

[TestFixture]
public class ZenjectTests : ZenjectUnitTestFixture
{
    [Inject] private ProjectContext ProjectContext { get; }

    [SetUp]
    public void CommonInstall()
    {
        Container.Bind<ProjectContext>().FromInstance(ProjectContextAccessor.GetProjectContext()).AsSingle().NonLazy();
        Container.Inject(this);
    }

    [Test]
    public void ProjectContextExistTest()
    {
        Assert.NotNull(ProjectContext);
    }
}