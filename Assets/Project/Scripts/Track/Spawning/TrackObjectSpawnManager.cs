using System;
using Scripts.Track.Spawning.Pooling;
using UnityEngine;

namespace Scripts.Track.Spawning
{
    public class TrackObjectSpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform trackTransform;

        public Action<GameObject> OnTrackObjectSpawned { get; set; }
        public Action<GameObject> OnTrackObjectDestroyed { get; set; }

        private ObjectPoolManager _objectPoolManager;

        private void Awake()
        {
            _objectPoolManager = FindObjectOfType<ObjectPoolManager>();
        }

        public GameObject SpawnTrackObject(GameObject prefab, Vector3 offset)
        {
            var trackObject = _objectPoolManager.CreateObject(prefab);

            trackObject.transform.SetParent(trackTransform);
            trackObject.transform.localPosition = Vector3.zero;
            trackObject.transform.position += TrackParameters.Instance.SpawnOffset + offset;

            OnTrackObjectSpawned?.Invoke(trackObject);
            return trackObject;
        }

        public void DestroyTrackObject(GameObject trackObject)
        {
            OnTrackObjectDestroyed?.Invoke(trackObject);
            _objectPoolManager.DestroyObject(trackObject);
        }

    }
}