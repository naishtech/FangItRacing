using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace FangItRacing.Tests.PlayMode
{
    [TestFixture]
    public class LapDetectionPlayModeTests
    {
        private GameObject _motorcycle;
        private GameObject _startFinishLine;
        private LapManager _lapManager;

        [SetUp]
        public void SetUp()
        {
            // Create a motorcycle with the required tag and collider
            _motorcycle = new GameObject("Motorcycle");
            _motorcycle.tag = "Motorcycle";
            var mcCollider = _motorcycle.AddComponent<BoxCollider2D>();
            mcCollider.isTrigger = true;

            // Create start/finish line trigger
            _startFinishLine = new GameObject("StartFinish");
            var sfCollider = _startFinishLine.AddComponent<BoxCollider2D>();
            sfCollider.isTrigger = true;
            _lapManager = _startFinishLine.AddComponent<LapManager>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_motorcycle);
            Object.DestroyImmediate(_startFinishLine);
        }

        [UnityTest]
        public IEnumerator LapManager_CrossFinishLine_RegistersLap()
        {
            _lapManager.StartRace(Time.time);
            Assert.AreEqual(0, _lapManager.LapCount,
                "Lap count should be 0 before crossing the line.");

            // Move motorcycle into the trigger
            _motorcycle.transform.position = _startFinishLine.transform.position;
            yield return new WaitForFixedUpdate();
            yield return null;

            Assert.AreEqual(1, _lapManager.LapCount,
                "Lap count should increment after crossing start/finish line.");
        }

        [UnityTest]
        public IEnumerator LapManager_MultipleLaps_IncrementsCount()
        {
            _lapManager.StartRace(Time.time);

            // Cross line — lap 1
            _motorcycle.transform.position = _startFinishLine.transform.position;
            yield return new WaitForFixedUpdate();
            yield return null;

            // Move away
            _motorcycle.transform.position = Vector3.right * 10f;
            yield return new WaitForFixedUpdate();
            yield return null;

            // Cross again — lap 2
            _motorcycle.transform.position = _startFinishLine.transform.position;
            yield return new WaitForFixedUpdate();
            yield return null;

            Assert.AreEqual(2, _lapManager.LapCount,
                "Lap count should be 2 after two crossings.");
        }

        [UnityTest]
        public IEnumerator LapManager_BestLap_UpdatesAcrossLaps()
        {
            _lapManager.StartRace(Time.time);

            // First crossing
            _motorcycle.transform.position = _startFinishLine.transform.position;
            yield return new WaitForFixedUpdate();
            yield return null;

            Assert.Less(_lapManager.BestLap, float.MaxValue,
                "BestLap should update after first lap.");
        }
    }
}
