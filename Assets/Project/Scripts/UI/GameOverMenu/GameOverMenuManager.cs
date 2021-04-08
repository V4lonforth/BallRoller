using Scripts.Players;
using UnityEngine;

namespace Scripts.UI.GameOverMenu
{
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