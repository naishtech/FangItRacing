using UnityEngine;

namespace FangItRacing
{
    /// <summary>
    /// Arcade-style top-down motorcycle movement controller.
    /// Handles acceleration, speed-sensitive steering, and drift.
    /// </summary>
    public class MotorcycleController : MonoBehaviour
    {
        [SerializeField] private float maxSpeed = 10f;
        [SerializeField] private float acceleration = 5f;
        [SerializeField] private float turnRate = 180f;
        [SerializeField] private float driftFactor = 0.9f;
        [SerializeField] private float offTrackMultiplier = 0.3f;

        private IMotorcycleInput _input;
        private Vector2 _velocity;
        private float _currentSpeed;
        private float _activeSpeedMultiplier = 1f;

        public bool IsControllable { get; set; }
        public float CurrentSpeed => _currentSpeed;

        /// <summary>
        /// Sets the off-track speed multiplier. 1.0 = normal, 0.3 = off-track slow.
        /// </summary>
        public void SetSpeedMultiplier(float multiplier)
        {
            _activeSpeedMultiplier = multiplier;
        }

        public void SetInput(IMotorcycleInput input)
        {
            _input = input;
        }

        private void Update()
        {
            Tick(Time.deltaTime);
        }

        /// <summary>
        /// Public tick for testability. Called by Update() in play mode.
        /// </summary>
        public void Tick(float deltaTime)
        {
            if (_input == null || !IsControllable) return;

            Vector2 forward = transform.up;

            // Acceleration (AC-01): apply force along forward vector
            float accelInput = _input.Accelerate;
            _velocity += forward * (accelInput * acceleration * deltaTime);

            // Clamp to max speed (modified by active multiplier for off-track)
            float effectiveMaxSpeed = maxSpeed * _activeSpeedMultiplier;
            _currentSpeed = _velocity.magnitude;
            if (_currentSpeed > effectiveMaxSpeed)
            {
                _velocity = _velocity.normalized * effectiveMaxSpeed;
                _currentSpeed = effectiveMaxSpeed;
            }

            // Steering (AC-02): rotate at speed-sensitive turn rate
            float steerInput = _input.Steer;
            if (_currentSpeed > 0.01f)
            {
                float turnAmount = steerInput * turnRate * (_currentSpeed / maxSpeed) * deltaTime;
                transform.Rotate(0f, 0f, -turnAmount);

                // Drift (AC-03): preserve fraction of lateral velocity after rotation
                Vector2 newForward = transform.up;
                Vector2 newRight = transform.right;

                float forwardSpeed = Vector2.Dot(_velocity, newForward);
                float lateralSpeed = Vector2.Dot(_velocity, newRight);

                _velocity = newForward * forwardSpeed + newRight * (lateralSpeed * driftFactor);
                _currentSpeed = _velocity.magnitude;
            }

            // Apply position
            transform.position += (Vector3)_velocity * deltaTime;
        }
    }
}
