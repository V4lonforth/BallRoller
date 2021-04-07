using Scripts.Players;
using UnityEngine;

namespace Scripts.Input
{
    public class PlayerInputHandler : DefaultInputHandler
    {
        private Vector2 _lastInputPosition;
        private Player _player;

        private float horizontalDistance;
        
        protected new void Awake()
        {
            base.Awake();
            _player = FindObjectOfType<Player>();

            horizontalDistance = GetHorizontalDistance();
        }
        
        protected override void HandlePress(Vector2 inputPosition)
        {
            _lastInputPosition = inputPosition;
        }

        protected override void HandleHold(Vector2 inputPosition)
        {
            MovePlayer(inputPosition - _lastInputPosition);
            _lastInputPosition = inputPosition;
        }

        protected override void HandleRelease(Vector2 inputPosition)
        {
            MovePlayer(Vector2.zero);
        }

        private void MovePlayer(Vector2 delta)
        {
            _player.HorizontalMovement += delta.x / Screen.width * horizontalDistance;
        }

        private float GetHorizontalDistance()
        {
            var camera = Camera.main;
            
            var playerDelta = _player.transform.position - camera.transform.position;
            var cameraForwardDirection = camera.transform.rotation * Vector3.forward;
            var projectedDelta = Vector3.Dot(cameraForwardDirection, playerDelta) * cameraForwardDirection;

            return Mathf.Tan(camera.fieldOfView * Mathf.Deg2Rad / 2f) * camera.aspect * projectedDelta.magnitude * 2f;
        } 
    }
}