using NUnit.Framework;
using Zenject;

namespace Tests
{
    public class ScoreTest : ZenjectUnitTestFixture
    {

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            Container.BindInterfacesTo<ScoreManager>().AsSingle();
            Container.Bind<ScoreManager.Settings>().FromInstance(new ScoreManager.Settings());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 100)]
        [TestCase(2, 240)]
        [TestCase(3, 360)]
        [TestCase(4, 480)]
        public void ChangeScoreTest(int lineCount, int expectedResult)
        {
            var scoremanager = Container.Resolve<IScoreManager>();
            var settings = Container.Resolve<ScoreManager.Settings>();
            settings._lineScore = 100;
            settings._lineScoreMultiplier = 1.2f;
            scoremanager.AddLineScore(lineCount);
            
            Assert.AreEqual(expectedResult, scoremanager.Score);
        }
    }
}
