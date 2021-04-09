using System;
using Scripts.Track;
using UnityEngine;

namespace Scripts.Players
{
    /// <summary>
    /// Base class for player
    /// </summary>
    public abstract class Player : MonoBehaviour
    {
        public Action<float> OnMoved { get; set; }
        public Action OnDestroyed { get; set; }
        
        public float HorizontalMovement { get; set; }

        [SerializeField] private float speed;

        protected Rigidbody Rigidbody;
        
        protected void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        public void Destroy()
        {
            Destroy(gameObject);
            OnDestroyed?.Invoke();
        }

        protected void FixedUpdate()
        {
            var forwardVelocity = TrackParameters.Instance.forwardMovementDirection * (speed * Time.deltaTime);
            var horizontalVelocity = TrackParameters.Instance.horizontalMovementDirection * HorizontalMovement;

            var horizontalPosition = Vector3.ClampMagnitude(transform.position + horizontalVelocity,
                TrackParameters.Instance.trackWidth / 2f);
            
            Move(forwardVelocity + horizontalPosition - transform.position);
            Rigidbody.MovePosition(horizontalPosition);
            
            OnMoved?.Invoke(speed * Time.deltaTime);

            HorizontalMovement = 0f;
        }

        protected abstract void Move(Vector3 velocity);
    }
}