using Scripts.Players;
using UnityEngine;

namespace Scripts.Track.Spawning
{
    public class GroundSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject groundPrefab;
        [SerializeField] private float groundLength;

        private TrackObjectSpawnManager _spawnManager;
        private float _remainingDistanceToSpawn;
        
        private void Awake()
        {
            _spawnManager = FindObjectOfType<TrackObjectSpawnManager>();
            FindObjectOfType<Player>().OnMoved += PassDistance;
        }

        private void PassDistance(float distance)
        {
            _remainingDistanceToSpawn -= distance;

            if (_remainingDistanceToSpawn > 0) return;

            _remainingDistanceToSpawn = groundLength;
            _spawnManager.SpawnTrackObject(groundPrefab, 0f);
        }
    }
}