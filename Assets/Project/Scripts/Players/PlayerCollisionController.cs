using UnityEngine;

namespace Scripts.Players
{
    /// <summary>
    /// Class that kills player when detects collision
    /// </summary>
    [RequireComponent(typeof(Player))]
    public class PlayerCollisionController : MonoBehaviour
    {
        [SerializeField] private LayerMask targetLayerMask;
        
        private Player _player;

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (targetLayerMask != (targetLayerMask | (1 << other.gameObject.layer))) return;
            
            _player.Destroy();
        }
    }
}