using Scripts.Players;
using UnityEngine;

namespace Scripts.Track.Spawning
{
    public class GroundSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject groundPrefab;
        [SerializeField] private float groundLength;
        [SerializeField] private Vector3 spawnOffset;


        private TrackObjectSpawnManager _spawnManager;
        private float _remainingDistanceToSpawn;

        private void Awake()
        {
            _spawnManager = FindObjectOfType<TrackObjectSpawnManager>();
            FindObjectOfType<Player>().OnMoved += PassDistance;
        }

        private void Start()
        {
            _spawnManager.SpawnTrackObject(groundPrefab,
                TrackParameters.Instance.forwardMovementDirection * (-groundLength / 2f) + spawnOffset);
        }

        private void PassDistance(float distance)
        {
            _remainingDistanceToSpawn -= distance;

            if (_remainingDistanceToSpawn > 0) return;

            _spawnManager.SpawnTrackObject(groundPrefab,
                TrackParameters.Instance.forwardMovementDirection * (groundLength / 2f + _remainingDistanceToSpawn) +
                spawnOffset);
            _remainingDistanceToSpawn += groundLength;
        }
    }
}