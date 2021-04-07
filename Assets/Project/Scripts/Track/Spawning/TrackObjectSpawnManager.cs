using System;
using Scripts.Players;
using Scripts.Utils;
using UnityEngine;
using Random = System.Random;

namespace Scripts.Track.Spawning
{
    public class TrackObjectSpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform trackTransform;
        [SerializeField] private Vector3 trackBasePosition;
        [SerializeField] private float spawnMargin;

        public Action<GameObject> OnTrackObjectSpawned { get; set; }
        public Action<GameObject> OnTrackObjectDestroyed { get; set; }

        public Vector3 SpawnOffset { get; private set; }

        private void Awake()
        {
            SpawnOffset = GetSpawnOffset();
        }

        public GameObject SpawnTrackObject(GameObject prefab, Vector3 offset)
        {
            var trackObject = Instantiate(prefab, trackTransform);
            trackObject.transform.position += SpawnOffset + offset;

            OnTrackObjectSpawned?.Invoke(trackObject);
            return trackObject;
        }

        public void DestroyTrackObject(GameObject trackObject)
        {
            OnTrackObjectDestroyed?.Invoke(trackObject);
            Destroy(trackObject);
        }

        private Vector3 GetSpawnOffset()
        {
            var camera = Camera.main;

            if (camera == null)
                return Vector3.zero;

            var cameraDirection = camera.transform.forward;
            var cameraTopDirection = Quaternion.Euler(-camera.fieldOfView / 2f, 0f, 0f) * cameraDirection;

            var basePositionOffset = trackBasePosition - camera.transform.position;
            var basePositionDirection = basePositionOffset.normalized;

            var cameraAngle = Vector3.Angle(basePositionDirection, cameraTopDirection);
            var basePositionAngle =
                Vector3.Angle(-basePositionDirection, TrackParameters.Instance.forwardMovementDirection);
            var spawnOffsetAngle = 180 - cameraAngle - basePositionAngle;

            var spawnOffset = (spawnMargin + basePositionOffset.magnitude *
                (Mathf.Sin(basePositionAngle * Mathf.Deg2Rad) /
                 Mathf.Sin(spawnOffsetAngle * Mathf.Deg2Rad))) * TrackParameters.Instance.forwardMovementDirection;

            return spawnOffset;
        }
    }
}