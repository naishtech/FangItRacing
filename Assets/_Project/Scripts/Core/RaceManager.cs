using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace FangItRacing
{
    /// <summary>
    /// Orchestrates the race lifecycle: countdown → racing → ended.
    /// Wires together MotorcycleController, LapManager, and HUD.
    /// </summary>
    public class RaceManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private MotorcycleController motorcycle;
        [SerializeField] private LapManager lapManager;

        [Header("Countdown")]
        [SerializeField] private float countdownDuration = 3f;
        [SerializeField] private float goDisplayDuration = 0.5f;

        public RaceState CurrentState { get; private set; } = RaceState.Countdown;
        public float RaceTime { get; private set; }
        public float BestLap => lapManager != null ? lapManager.BestLap : float.MaxValue;
        public int LapCount => lapManager != null ? lapManager.LapCount : 0;

        public event Action<RaceState> OnRaceStateChanged;
        public event Action<LapData> OnLapCompleted;

        private void Start()
        {
            if (motorcycle != null)
                motorcycle.IsControllable = false;

            StartCoroutine(CountdownRoutine());
        }

        private IEnumerator CountdownRoutine()
        {
            CurrentState = RaceState.Countdown;
            OnRaceStateChanged?.Invoke(CurrentState);

            // Emit countdown ticks: 3, 2, 1
            for (int i = Mathf.CeilToInt(countdownDuration); i > 0; i--)
            {
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitForSeconds(goDisplayDuration);

            // GO!
            CurrentState = RaceState.Racing;
            OnRaceStateChanged?.Invoke(CurrentState);

            if (motorcycle != null)
                motorcycle.IsControllable = true;

            if (lapManager != null)
            {
                lapManager.StartRace(Time.time);
                lapManager.OnLapCompleted += HandleLapCompleted;
            }
        }

        private void Update()
        {
            if (CurrentState == RaceState.Racing)
            {
                RaceTime += Time.deltaTime;
            }
        }

        private void HandleLapCompleted(LapData lapData)
        {
            OnLapCompleted?.Invoke(lapData);
        }

        /// <summary>
        /// Ends the race and returns to the menu.
        /// </summary>
        public void EndRace()
        {
            CurrentState = RaceState.Ended;
            OnRaceStateChanged?.Invoke(CurrentState);

            if (motorcycle != null)
                motorcycle.IsControllable = false;

            if (lapManager != null)
                lapManager.OnLapCompleted -= HandleLapCompleted;
        }

        private void OnDestroy()
        {
            if (lapManager != null)
                lapManager.OnLapCompleted -= HandleLapCompleted;
        }
    }
}
