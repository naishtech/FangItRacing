namespace FangItRacing
{
    /// <summary>
    /// Abstracts motorcycle input so the controller can be tested without
    /// depending on Unity's Input System directly.
    /// </summary>
    public interface IMotorcycleInput
    {
        /// <summary>0.0 = no input, 1.0 = full accelerate.</summary>
        float Accelerate { get; }

        /// <summary>-1.0 = full left, 0.0 = center, 1.0 = full right.</summary>
        float Steer { get; }
    }
}
