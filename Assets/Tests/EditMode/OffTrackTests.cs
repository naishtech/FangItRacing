using NUnit.Framework;
using UnityEngine;

namespace FangItRacing.Tests.EditMode
{
    [TestFixture]
    public class OffTrackTests
    {
        private GameObject _gameObject;
        private MotorcycleController _controller;
        private MockMotorcycleInput _mockInput;

        [SetUp]
        public void SetUp()
        {
            _gameObject = new GameObject("TestMotorcycle");
            _controller = _gameObject.AddComponent<MotorcycleController>();
            _mockInput = new MockMotorcycleInput();
            _controller.SetInput(_mockInput);
            _controller.IsControllable = true;
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_gameObject);
        }

        [Test]
        public void MotorcycleController_OffTrack_ReducesMaxSpeed()
        {
            // Build speed to max on-track
            _mockInput.Accelerate = 1f;
            _mockInput.Steer = 0f;
            _controller.SetSpeedMultiplier(1f);
            for (int i = 0; i < 200; i++) _controller.Tick(0.02f);

            float onTrackSpeed = _controller.CurrentSpeed;
            Assert.Greater(onTrackSpeed, 0f);

            // Apply off-track multiplier
            _controller.SetSpeedMultiplier(0.3f);

            // Speed should reduce toward 30% of max
            for (int i = 0; i < 100; i++) _controller.Tick(0.02f);

            float offTrackSpeed = _controller.CurrentSpeed;
            Assert.Less(offTrackSpeed, onTrackSpeed,
                "Speed should drop when off-track multiplier is applied.");
        }

        [Test]
        public void MotorcycleController_OffTrack_RestoresSpeedWhenBackOnTrack()
        {
            _mockInput.Accelerate = 1f;
            _mockInput.Steer = 0f;
            _controller.SetSpeedMultiplier(1f);
            for (int i = 0; i < 200; i++) _controller.Tick(0.02f);

            float onTrackSpeed = _controller.CurrentSpeed;
            Assert.Greater(onTrackSpeed, 0f);

            // Go off-track
            _controller.SetSpeedMultiplier(0.3f);
            for (int i = 0; i < 50; i++) _controller.Tick(0.02f);

            float offTrackSpeed = _controller.CurrentSpeed;
            Assert.Less(offTrackSpeed, onTrackSpeed);

            // Return to track
            _controller.SetSpeedMultiplier(1f);
            for (int i = 0; i < 200; i++) _controller.Tick(0.02f);

            Assert.Greater(_controller.CurrentSpeed, offTrackSpeed,
                "Speed should increase when returning to track.");
        }
    }
}
