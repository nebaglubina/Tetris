using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.TestTools;
using Zenject;

namespace Tests
{
    public class ScorePlaymodeTest : ZenjectUnitTestFixture
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            Container.Bind<ScoreManager>().AsSingle();
        }

        
        [Test]
        [TestCase(1, 100)]
        [TestCase(2, 240)]
        [TestCase(3, 360)]
        [TestCase(4, 480)]
        public void ChangeScoreTest(int lineCount, int expectedResult)
        {
            var scoremanager = Container.Resolve<ScoreManager>();
            scoremanager.AddLineScore(lineCount);
            
            Assert.AreEqual(expectedResult, scoremanager.Score);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator EndGameTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
