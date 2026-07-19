using UnityEngine;
using UnityEngine.InputSystem;

namespace FangItRacing
{
    /// <summary>
    /// Bridges Unity's Input System to IMotorcycleInput.
    /// Reads Accelerate and Steer values from the InputActions asset.
    /// </summary>
    public class InputSystemMotorcycleInput : MonoBehaviour, IMotorcycleInput
    {
        [SerializeField] private InputActionAsset inputActions;

        private InputAction _accelerateAction;
        private InputAction _steerAction;

        public float Accelerate { get; private set; }
        public float Steer { get; private set; }

        private void Awake()
        {
            if (inputActions == null)
            {
                Debug.LogError($"{nameof(InputSystemMotorcycleInput)}: InputActionAsset not assigned.");
                return;
            }

            var playerMap = inputActions.FindActionMap("Player");
            if (playerMap == null)
            {
                Debug.LogError($"{nameof(InputSystemMotorcycleInput)}: 'Player' action map not found.");
                return;
            }

            _accelerateAction = playerMap.FindAction("Accelerate");
            _steerAction = playerMap.FindAction("Steer");

            if (_accelerateAction == null || _steerAction == null)
            {
                Debug.LogError($"{nameof(InputSystemMotorcycleInput)}: Required actions not found.");
            }
        }

        private void OnEnable()
        {
            inputActions?.Enable();
        }

        private void OnDisable()
        {
            inputActions?.Disable();
        }

        private void Update()
        {
            if (_accelerateAction != null)
                Accelerate = _accelerateAction.ReadValue<float>();

            if (_steerAction != null)
                Steer = _steerAction.ReadValue<float>();
        }
    }
}
