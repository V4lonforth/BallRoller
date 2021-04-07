using UnityEngine;

namespace Scripts.Players
{
    public class BallPlayer : Player
    {
        [SerializeField] private float radius = 0.5f;

        protected override void Move(Vector3 velocity)
        {
            var rotationAxis = Vector3.Cross(velocity.normalized, Vector3.up);
            transform.RotateAround(transform.position, rotationAxis, velocity.magnitude / -(2 * Mathf.PI * radius) * 360);
        }
    }
}