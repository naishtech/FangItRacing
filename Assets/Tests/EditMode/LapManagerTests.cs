using NUnit.Framework;
using UnityEngine;

namespace FangItRacing.Tests.EditMode
{
    [TestFixture]
    public class LapManagerTests
    {
        private GameObject _gameObject;
        private LapManager _manager;

        [SetUp]
        public void SetUp()
        {
            _gameObject = new GameObject("TestLapManager");
            _manager = _gameObject.AddComponent<LapManager>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_gameObject);
        }

        [Test]
        public void LapData_StoresValuesCorrectly()
        {
            var lap = new LapData(3, 45.23f);

            Assert.AreEqual(3, lap.LapNumber);
            Assert.AreEqual(45.23f, lap.LapTime, 0.001f);
            Assert.IsTrue(lap.Timestamp > System.DateTime.MinValue);
        }

        [Test]
        public void LapManager_StartRace_ResetsState()
        {
            _manager.StartRace(10f);

            Assert.AreEqual(0, _manager.LapCount);
            Assert.AreEqual(float.MaxValue, _manager.BestLap);
            Assert.AreEqual(0, _manager.LapTimes.Count);
        }

        [Test]
        public void LapManager_InitialBestLap_IsMaxValue()
        {
            Assert.AreEqual(float.MaxValue, _manager.BestLap,
                "BestLap should start at MaxValue so any time beats it.");
        }

        [Test]
        public void LapManager_RaceStartTime_IsSet()
        {
            _manager.StartRace(42f);

            Assert.AreEqual(42f, _manager.RaceStartTime);
        }
    }
}
