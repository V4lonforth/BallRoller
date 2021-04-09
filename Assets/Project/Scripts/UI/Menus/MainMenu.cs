using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.UI.Menus
{
    /// <summary>
    /// Class that controls main menu
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("GameScene");
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