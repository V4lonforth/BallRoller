using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.UI.GameOverMenu
{
    public class GameOverMenu : MonoBehaviour
    {
        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Quit()
        {     
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}