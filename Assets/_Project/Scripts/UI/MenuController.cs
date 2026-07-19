using UnityEngine;
using UnityEngine.SceneManagement;

namespace FangItRacing
{
    /// <summary>
    /// Handles main menu button actions and displays the best saved time.
    /// </summary>
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private string raceSceneName = "RaceScene";

        public void StartRace()
        {
            SceneManager.LoadScene(raceSceneName);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
