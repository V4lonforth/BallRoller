using UnityEngine;

namespace Scripts.Track
{
    public class StaticTrackObject : MonoBehaviour, ITrackObject
    {
        public GameObject GameObject => gameObject;
        
        [SerializeField] private float radius;

        private Rigidbody _rigidbody;

        protected void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(float distance)
        {
            _rigidbody.MovePosition(transform.position + TrackParameters.Instance.forwardMovementDirection * distance);
        }

        public bool CheckFinish()
        {
            return Vector3.Dot(transform.position - TrackParameters.Instance.trackBasePosition,
                       TrackParameters.Instance.forwardMovementDirection) + radius <
                   Vector3.Dot(TrackParameters.Instance.DestroyOffset - TrackParameters.Instance.trackBasePosition,
                       TrackParameters.Instance.forwardMovementDirection);
        }
    }
}