using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace FangItRacing.Tests.PlayMode
{
    [TestFixture]
    public class RaceFlowPlayModeTests
    {
        private GameObject _raceManagerObj;
        private RaceManager _raceManager;
        private GameObject _motorcycleObj;
        private MotorcycleController _controller;

        [SetUp]
        public void SetUp()
        {
            _motorcycleObj = new GameObject("Motorcycle");
            _controller = _motorcycleObj.AddComponent<MotorcycleController>();
            _controller.IsControllable = false;

            _raceManagerObj = new GameObject("RaceManager");
            _raceManager = _raceManagerObj.AddComponent<RaceManager>();

            // Wire via reflection for the serialized motorcycle field
            var field = typeof(RaceManager).GetField("motorcycle",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field?.SetValue(_raceManager, _controller);
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_motorcycleObj);
            Object.DestroyImmediate(_raceManagerObj);
        }

        [UnityTest]
        public IEnumerator RaceManager_Countdown_ReleasesControlAfterGo()
        {
            Assert.IsFalse(_controller.IsControllable,
                "Motorcycle should be locked during countdown.");
            Assert.AreEqual(RaceState.Countdown, _raceManager.CurrentState);

            // Wait for countdown (3s + 0.5s GO)
            yield return new WaitForSeconds(4f);

            Assert.AreEqual(RaceState.Racing, _raceManager.CurrentState,
                "Should be in Racing state after countdown.");
            Assert.IsTrue(_controller.IsControllable,
                "Motorcycle should be controllable after GO.");
        }
    }
}
