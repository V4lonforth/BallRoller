using UnityEngine;

namespace Scripts.Players
{
    [RequireComponent(typeof(Player))]
    public class PlayerCollisionController : MonoBehaviour
    {
        private Player _player;

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _player.Destroy();
        }
    }
}