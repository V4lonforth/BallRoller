using Scripts.Players;
using UnityEngine;

namespace Scripts.UI.Menus
{
    /// <summary>
    /// Class that shows game over menu after player's death
    /// </summary>
    public class GameOverMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        
        private void Awake()
        {
            menu.SetActive(false);
            FindObjectOfType<Player>().OnDestroyed += ShowMenu;
        }

        private void ShowMenu()
        {
            menu.SetActive(true);
        }
    }
}