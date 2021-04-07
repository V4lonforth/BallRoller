using UnityEngine;

namespace Scripts.Track
{
    public class StaticTrackObject : MonoBehaviour, ITrackObject
    {
        private Rigidbody _rigidbody;
        
        protected void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        public void Move(float distance)
        {
            _rigidbody.MovePosition(transform.position + TrackParameters.Instance.forwardMovementDirection * distance);
        }
    }
}