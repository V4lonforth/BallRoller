using System;
using UnityEngine;

namespace Scripts.Track.Spawning
{
    public class TrackObjectSpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform trackTransform;

        public Action<GameObject> OnTrackObjectSpawned { get; set; }
        public Action<GameObject> OnTrackObjectDestroyed { get; set; }

        public GameObject SpawnTrackObject(GameObject prefab, Vector3 offset)
        {
            var trackObject = Instantiate(prefab, trackTransform);
            trackObject.transform.position += TrackParameters.Instance.SpawnOffset + offset;

            OnTrackObjectSpawned?.Invoke(trackObject);
            return trackObject;
        }

        public void DestroyTrackObject(GameObject trackObject)
        {
            OnTrackObjectDestroyed?.Invoke(trackObject);
            Destroy(trackObject);
        }

    }
}