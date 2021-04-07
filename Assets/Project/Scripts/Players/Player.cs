using System;
using UnityEngine;

namespace Scripts.Players
{
    public abstract class Player : MonoBehaviour
    {
        public Action<Vector2> OnMoved { get; set; }
        public float HorizontalMovement { get; set; }

        [SerializeField] private float speed;

        private static readonly Vector3 ForwardMovementDirection = Vector3.forward;
        private static readonly Vector3 HorizontalMovementDirection = Vector3.right;
        
        protected void Update()
        {
            var velocity = ForwardMovementDirection * (speed * Time.deltaTime) + HorizontalMovementDirection * HorizontalMovement;
            Move(velocity);
            
            OnMoved?.Invoke(velocity);
        }

        protected abstract void Move(Vector3 velocity);
    }
}