using Scripts.Utils;
using UnityEngine;

namespace Scripts.Track
{
    /// <summary>
    /// Singleton class that contains track parameters
    /// </summary>
    public class TrackParameters : Singleton<TrackParameters>
    {
        public Vector3 forwardMovementDirection = Vector3.forward;
        public Vector3 horizontalMovementDirection = Vector3.right;
        public Vector3 trackBasePosition = new Vector3(0f, -0.5f, 0f);
        public float trackWidth = 8f;
        public float cameraBorderMargin = 2f;

        public Vector3 SpawnOffset { get; private set; }
        public Vector3 DestroyOffset { get; private set; }
        
        private void Awake()
        {
            SpawnOffset = FindCameraBorder(1);
            DestroyOffset = FindCameraBorder(-1);
        }
        
        private Vector3 FindCameraBorder(int borderDirection)
        {
            var camera = Camera.main;

            if (camera == null)
                return Vector3.zero;

            var cameraDirection = camera.transform.forward;
            var cameraBorderDirection = Quaternion.Euler(-borderDirection * camera.fieldOfView / 2f, 0f, 0f) * cameraDirection;

            var basePositionOffset = TrackParameters.Instance.trackBasePosition - camera.transform.position;
            var basePositionDirection = basePositionOffset.normalized;

            var cameraAngle = Vector3.Angle(basePositionDirection, cameraBorderDirection);
            var basePositionAngle =
                Vector3.Angle(-basePositionDirection, borderDirection * TrackParameters.Instance.forwardMovementDirection);
            var spawnOffsetAngle = 180 - cameraAngle - basePositionAngle;

            var spawnOffset = (cameraBorderMargin + basePositionOffset.magnitude *
                (Mathf.Sin(cameraAngle * Mathf.Deg2Rad) /
                 Mathf.Sin(spawnOffsetAngle * Mathf.Deg2Rad))) * borderDirection * TrackParameters.Instance.forwardMovementDirection;

            return spawnOffset;
        }
    }
}