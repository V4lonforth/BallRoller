using System.Collections.Generic;
using Scripts.Players;
using Scripts.Track.Spawning;
using Scripts.Track.TrackObjects;
using UnityEngine;

namespace Scripts.Track
{
    /// <summary>
    /// Class that controls every object on track
    /// </summary>
    public class TrackManager : MonoBehaviour
    {
        private readonly List<ITrackObject> _trackObjects = new List<ITrackObject>();
        private Player _player;

        private TrackObjectSpawnManager _spawnManager;
        
        private void Awake()
        {
            _player = FindObjectOfType<Player>();
            _player.OnMoved += MoveTrack;

            _spawnManager = FindObjectOfType<TrackObjectSpawnManager>();
            _spawnManager.OnTrackObjectSpawned += AddTrackObject;
            _spawnManager.OnTrackObjectDestroyed += RemoveTrackObject;
        }

        private void MoveTrack(float distance)
        {
            _trackObjects.ForEach(obj => obj.Move(-distance));

            foreach (var trackObject in _trackObjects.FindAll(obj => obj.CheckFinish()))
            {
                _spawnManager.DestroyTrackObject(trackObject.GameObject);
            }
        }

        private void RemoveTrackObject(GameObject trackGameObject)
        {
            _trackObjects.Remove(trackGameObject.GetComponent<ITrackObject>());
        }
        private void AddTrackObject(GameObject trackGameObject)
        {
            if (trackGameObject.GetComponent<ITrackObject>() is { } trackObject)
                _trackObjects.Add(trackObject);
        }
    }
}