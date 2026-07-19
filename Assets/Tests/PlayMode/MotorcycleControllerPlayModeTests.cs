using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace FangItRacing.Tests.PlayMode
{
    [TestFixture]
    public class MotorcycleControllerPlayModeTests
    {
        private GameObject _motorcycle;
        private MotorcycleController _controller;
        private PlayModeMockInput _mockInput;

        [SetUp]
        public void SetUp()
        {
            _motorcycle = new GameObject("TestMotorcycle");
            var sr = _motorcycle.AddComponent<SpriteRenderer>();
            sr.sprite = Sprite.Create(Texture2D.whiteTexture,
                new Rect(0, 0, 1, 1), Vector2.one * 0.5f);

            _controller = _motorcycle.AddComponent<MotorcycleController>();
            _controller.IsControllable = true;

            _mockInput = new PlayModeMockInput();
            _controller.SetInput(_mockInput);
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_motorcycle);
        }

        [UnityTest]
        public IEnumerator MotorcycleController_Accelerate_MovesPosition()
        {
            Vector3 startPosition = _motorcycle.transform.position;

            _mockInput.Accelerate = 1f;
            _mockInput.Steer = 0f;

            yield return null;
            yield return null;
            yield return null;

            float distance = Vector3.Distance(startPosition, _motorcycle.transform.position);
            Assert.Greater(distance, 0f,
                "Motorcycle should move from its starting position when accelerating.");
        }

        [UnityTest]
        public IEnumerator MotorcycleController_Steer_RotatesInPlayMode()
        {
            _mockInput.Accelerate = 1f;
            _mockInput.Steer = 0f;

            for (int i = 0; i < 10; i++)
                yield return null;

            float rotationBefore = _motorcycle.transform.rotation.eulerAngles.z;

            _mockInput.Steer = 1f;
            yield return null;
            yield return null;

            float rotationAfter = _motorcycle.transform.rotation.eulerAngles.z;

            Assert.AreNotEqual(rotationBefore, rotationAfter,
                "Motorcycle should rotate when steering input is applied.");
        }
    }

    /// <summary>
    /// Inline test double for PlayMode — avoids cross-assembly dependency on Tests.EditMode.
    /// </summary>
    internal class PlayModeMockInput : IMotorcycleInput
    {
        public float Accelerate { get; set; }
        public float Steer { get; set; }
    }
}
