using NUnit.Framework;
using UnityEngine;

namespace FangItRacing.Tests.EditMode
{
    [TestFixture]
    public class RaceManagerTests
    {
        private GameObject _gameObject;
        private RaceManager _raceManager;

        [SetUp]
        public void SetUp()
        {
            _gameObject = new GameObject("TestRaceManager");
            _raceManager = _gameObject.AddComponent<RaceManager>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_gameObject);
        }

        [Test]
        public void RaceManager_StartsInCountdownState()
        {
            Assert.AreEqual(RaceState.Countdown, _raceManager.CurrentState,
                "RaceManager should start in Countdown state.");
        }

        [Test]
        public void RaceManager_EndRace_SetsEndedState()
        {
            _raceManager.EndRace();

            Assert.AreEqual(RaceState.Ended, _raceManager.CurrentState,
                "EndRace should transition to Ended state.");
        }

        [Test]
        public void RaceManager_RaceTime_StartsAtZero()
        {
            Assert.AreEqual(0f, _raceManager.RaceTime,
                "RaceTime should start at 0.");
        }

        [Test]
        public void RaceState_Enum_HasThreeValues()
        {
            var values = System.Enum.GetValues(typeof(RaceState));
            Assert.AreEqual(3, values.Length,
                "RaceState should have exactly 3 values.");
        }
    }
}
