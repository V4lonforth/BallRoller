using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.UI.Menus
{
    /// <summary>
    /// Class controls game over menu
    /// </summary>
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