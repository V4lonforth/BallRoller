using UnityEngine;

namespace Scripts.UI.Menus
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseButton;
        [SerializeField] private GameObject resumeButton;

        private void Awake()
        {
            SetPauseState(false);
        }

        public void Pause()
        {
            Time.timeScale = 0f;
            SetPauseState(true);
        }

        public void Resume()
        {
            Time.timeScale = 1f;
            SetPauseState(false);
        }

        private void SetPauseState(bool state)
        {
            pauseButton.SetActive(!state);
            resumeButton.SetActive(state);
        }
    }
}