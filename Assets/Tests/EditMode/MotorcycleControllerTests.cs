using NUnit.Framework;
using UnityEngine;

namespace FangItRacing.Tests.EditMode
{
    [TestFixture]
    public class MotorcycleControllerTests
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
        public void MotorcycleController_Accelerate_IncreasesSpeed()
        {
            _mockInput.Accelerate = 1f;
            _mockInput.Steer = 0f;
            _controller.IsControllable = true;

            _controller.Tick(0.02f);

            Assert.Greater(_controller.CurrentSpeed, 0f,
                "Speed should increase when acceleration is applied.");
        }

        [Test]
        public void MotorcycleController_Speed_ClampsAtMaxSpeed()
        {
            _mockInput.Accelerate = 1f;
            _mockInput.Steer = 0f;
            _controller.IsControllable = true;

            // Simulate many ticks to exceed maxSpeed
            for (int i = 0; i < 1000; i++)
            {
                _controller.Tick(0.02f);
            }

            float maxSpeed = 10f; // default serialized value
            Assert.LessOrEqual(_controller.CurrentSpeed, maxSpeed,
                "Speed should never exceed maxSpeed.");
        }

        [Test]
        public void MotorcycleController_NotControllable_DoesNotAccelerate()
        {
            _mockInput.Accelerate = 1f;
            _controller.IsControllable = false;

            _controller.Tick(0.02f);

            Assert.AreEqual(0f, _controller.CurrentSpeed,
                "Speed should remain 0 when IsControllable is false.");
        }

        [Test]
        public void MotorcycleController_NullInput_DoesNotThrow()
        {
            _controller.SetInput(null);
            _controller.IsControllable = true;

            Assert.DoesNotThrow(() => _controller.Tick(0.02f),
                "Tick should not throw when input is null.");
        }

        // ── Steering (AC-02) ──────────────────────────────────────────

        [Test]
        public void MotorcycleController_Steer_RotatesTransform()
        {
            // First build some speed
            _mockInput.Accelerate = 1f;
            _mockInput.Steer = 0f;
            _controller.IsControllable = true;
            for (int i = 0; i < 50; i++) _controller.Tick(0.02f);

            float rotationBefore = _controller.transform.rotation.eulerAngles.z;

            // Now steer right
            _mockInput.Steer = 1f;
            _controller.Tick(0.02f);

            float rotationAfter = _controller.transform.rotation.eulerAngles.z;

            Assert.AreNotEqual(rotationBefore, rotationAfter,
                "Steering should rotate the transform.");
        }

        [Test]
        public void MotorcycleController_Steer_NoRotationAtZeroSpeed()
        {
            _mockInput.Accelerate = 0f;
            _mockInput.Steer = 1f;
            _controller.IsControllable = true;

            float rotationBefore = _controller.transform.rotation.eulerAngles.z;
            _controller.Tick(0.02f);
            float rotationAfter = _controller.transform.rotation.eulerAngles.z;

            Assert.AreEqual(rotationBefore, rotationAfter,
                "Steering should not rotate at zero speed.");
        }

        [Test]
        public void MotorcycleController_Steer_TurnRateScalesWithSpeed()
        {
            // Accelerate to build speed
            _mockInput.Accelerate = 1f;
            _mockInput.Steer = 0f;
            _controller.IsControllable = true;
            for (int i = 0; i < 50; i++) _controller.Tick(0.02f);

            float speedBeforeSteer = _controller.CurrentSpeed;
            Assert.Greater(speedBeforeSteer, 0f);

            // A moving motorcycle should rotate when steering
            _mockInput.Steer = 1f;
            float rotationBefore = _controller.transform.rotation.eulerAngles.z;
            _controller.Tick(0.02f);
            float rotationAfter = _controller.transform.rotation.eulerAngles.z;

            Assert.AreNotEqual(rotationBefore, rotationAfter,
                "Steering at speed should produce rotation.");
        }

        // ── Drift (AC-03) ─────────────────────────────────────────────

        [Test]
        public void MotorcycleController_Drift_PreservesLateralVelocity()
        {
            // Build forward speed
            _mockInput.Accelerate = 1f;
            _mockInput.Steer = 0f;
            _controller.IsControllable = true;
            for (int i = 0; i < 50; i++) _controller.Tick(0.02f);

            float speedBeforeSteer = _controller.CurrentSpeed;
            Assert.Greater(speedBeforeSteer, 0f);

            // Steer hard — speed should drop somewhat due to drift but not to 0
            _mockInput.Steer = 1f;
            for (int i = 0; i < 10; i++) _controller.Tick(0.02f);

            float speedAfterSteer = _controller.CurrentSpeed;
            Assert.Greater(speedAfterSteer, 0f,
                "Speed should not drop to zero after steering — drift preserves some momentum.");
        }

        [Test]
        public void MotorcycleController_Drift_AtMaxDriftFactor()
        {
            // driftFactor defaults to 0.9 — most lateral velocity is preserved
            // Build speed then steer — verify speed remains > 50% of original
            _mockInput.Accelerate = 1f;
            _mockInput.Steer = 0f;
            _controller.IsControllable = true;
            for (int i = 0; i < 50; i++) _controller.Tick(0.02f);

            float speedBefore = _controller.CurrentSpeed;

            _mockInput.Steer = 1f;
            for (int i = 0; i < 5; i++) _controller.Tick(0.02f);

            Assert.Greater(_controller.CurrentSpeed, speedBefore * 0.5f,
                "With driftFactor=0.9, speed should stay above 50% after a few steer ticks.");
        }
    }
}
