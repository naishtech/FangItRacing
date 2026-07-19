namespace FangItRacing.Tests.EditMode
{
    /// <summary>
    /// Test double for IMotorcycleInput. Allows tests to set input values directly
    /// without requiring the Unity Input System.
    /// </summary>
    public class MockMotorcycleInput : IMotorcycleInput
    {
        public float Accelerate { get; set; }
        public float Steer { get; set; }
    }
}
