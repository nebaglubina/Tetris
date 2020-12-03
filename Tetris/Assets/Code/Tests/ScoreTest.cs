using NSubstitute;
using NUnit.Framework;
using Zenject;

namespace Tests
{
    public class ScoreTest : ZenjectUnitTestFixture
    {
        private ScoreManager.Settings _settings;
        
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _settings = Substitute.For<ScoreManager.Settings>();
            Container.BindInterfacesTo<ScoreManager>().AsSingle();
            Container.Bind<ScoreManager.Settings>().FromInstance(_settings);
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
            _settings = Container.Resolve<ScoreManager.Settings>();
            _settings._lineScore = 100;
            _settings._lineScoreMultiplier = 1.2f;
            scoremanager.AddLineScore(lineCount);
            
            Assert.AreEqual(expectedResult, scoremanager.Score);
        }
    }
}
