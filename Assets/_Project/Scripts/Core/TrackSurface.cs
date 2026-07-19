using UnityEngine;

namespace FangItRacing
{
    /// <summary>
    /// Detects whether a tagged object is on or off the track surface.
    /// Attach to trigger colliders placed outside the track boundaries.
    /// </summary>
    public class TrackSurface : MonoBehaviour
    {
        [SerializeField] private float offTrackSpeedMultiplier = 0.3f;
        [SerializeField] private string targetTag = "Motorcycle";

        /// <summary>Current speed multiplier based on track position.</summary>
        public float CurrentSpeedMultiplier { get; private set; } = 1f;

        private int _offTrackCount;

        private void Awake()
        {
            CurrentSpeedMultiplier = 1f;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(targetTag))
            {
                _offTrackCount++;
                CurrentSpeedMultiplier = offTrackSpeedMultiplier;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(targetTag))
            {
                _offTrackCount--;
                if (_offTrackCount <= 0)
                {
                    _offTrackCount = 0;
                    CurrentSpeedMultiplier = 1f;
                }
            }
        }
    }
}
