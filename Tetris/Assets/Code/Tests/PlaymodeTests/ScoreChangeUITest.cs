using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using Zenject;
using NSubstitute;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class ScoreChangeUITest : ZenjectUnitTestFixture
    {
        [UnitySetUp]
        public override void Setup()
        {
            SceneManager.LoadScene(0);
            base.Setup();
            Container.BindInterfacesTo<ScoreManager>().AsSingle();
            Container.Bind<ScoreManager.Settings>().FromInstance(new ScoreManager.Settings());
        }

        [Test]
        [TestCase(0, "0")]
        [TestCase(1, "100")]
        [TestCase(2, "240")]
        [TestCase(3, "360")]
        [TestCase(4, "480")]
        public void ChangeScoreTest(int lineCount, string expectedResult)
        {
            EventsObserver.Publish(new IStartGameplayEvent());
            var scoremanager = Container.Resolve<IScoreManager>();
            var settings = Container.Resolve<ScoreManager.Settings>();
            var scoreValueLabel = GameObject.Find("ScoreValueText").GetComponent<TextMeshProUGUI>();
            settings._lineScore = 100;
            settings._lineScoreMultiplier = 1.2f;
            scoremanager.AddLineScore(lineCount);
            Assert.AreEqual(expectedResult, scoreValueLabel.text);
        }
    }
}
