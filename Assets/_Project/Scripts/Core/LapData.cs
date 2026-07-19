using System;

namespace FangItRacing
{
    /// <summary>
    /// Immutable data object for a completed lap.
    /// </summary>
    public readonly struct LapData
    {
        public int LapNumber { get; }
        public float LapTime { get; }
        public DateTime Timestamp { get; }

        public LapData(int lapNumber, float lapTime)
        {
            LapNumber = lapNumber;
            LapTime = lapTime;
            Timestamp = DateTime.UtcNow;
        }
    }
}
