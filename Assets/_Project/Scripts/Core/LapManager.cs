using System;
using System.Collections.Generic;
using UnityEngine;

namespace FangItRacing
{
    /// <summary>
    /// Detects start/finish line crossings and tracks lap times.
    /// Attach to the start/finish line GameObject with a trigger collider.
    /// </summary>
    public class LapManager : MonoBehaviour
    {
        [SerializeField] private string motorcycleTag = "Motorcycle";

        public event Action<LapData> OnLapCompleted;

        public List<float> LapTimes { get; } = new List<float>();
        public float BestLap { get; private set; } = float.MaxValue;
        public int LapCount { get; private set; }
        public float RaceStartTime { get; set; }

        private float _lastCrossingTime;
        private bool _hasStarted;

        private void Awake()
        {
            BestLap = float.MaxValue;
        }

        public void StartRace(float startTime)
        {
            RaceStartTime = startTime;
            _lastCrossingTime = startTime;
            _hasStarted = true;
            LapCount = 0;
            LapTimes.Clear();
            BestLap = float.MaxValue;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(motorcycleTag)) return;
            if (!_hasStarted) return;

            RegisterLap();
        }

        private void RegisterLap()
        {
            float currentTime = Time.time;
            float lapTime = currentTime - _lastCrossingTime;
            _lastCrossingTime = currentTime;

            LapCount++;
            LapTimes.Add(lapTime);

            if (lapTime < BestLap)
            {
                BestLap = lapTime;
            }

            var lapData = new LapData(LapCount, lapTime);
            OnLapCompleted?.Invoke(lapData);
        }
    }
}
