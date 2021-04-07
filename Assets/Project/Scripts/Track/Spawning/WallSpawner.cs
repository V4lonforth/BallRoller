using Scripts.Players;
using UnityEngine;

namespace Scripts.Track.Spawning
{
    public class WallSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject trackObjectPrefab;

        [SerializeField] private float minDistanceToSpawn;
        [SerializeField] private float maxDistanceToSpawn;

        private TrackObjectSpawnManager _spawnManager;
        private float _remainingDistanceToSpawn;

        private void Awake()
        {
            _spawnManager = FindObjectOfType<TrackObjectSpawnManager>();
            _remainingDistanceToSpawn = GetDistanceToSpawn();

            FindObjectOfType<Player>().OnMoved += PassDistance;
        }

        private float GetDistanceToSpawn()
        {
            return Random.Range(minDistanceToSpawn, maxDistanceToSpawn);
        }

        private void PassDistance(float distance)
        {
            _remainingDistanceToSpawn -= distance;

            if (_remainingDistanceToSpawn > 0f) return;

            _remainingDistanceToSpawn = GetDistanceToSpawn();

            var width = TrackParameters.Instance.trackWidth;
            _spawnManager.SpawnTrackObject(trackObjectPrefab,
                TrackParameters.Instance.horizontalMovementDirection * Random.Range(-width / 2f, width / 2f));
        }
    }
}