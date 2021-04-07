using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Players
{
    public class PlayerCollisionController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}