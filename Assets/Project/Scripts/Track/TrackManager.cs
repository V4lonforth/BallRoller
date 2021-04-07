using System;
using System.Collections.Generic;
using Scripts.Players;
using Scripts.Track.Spawning;
using UnityEngine;

namespace Scripts.Track
{
    public class TrackManager : MonoBehaviour
    {
        private readonly List<ITrackObject> _trackObjects = new List<ITrackObject>();
        private Player _player;

        private void Awake()
        {
            _player = FindObjectOfType<Player>();
            _player.OnMoved += MoveTrack;

            var spawnManager = FindObjectOfType<TrackObjectSpawnManager>();
            spawnManager.OnTrackObjectSpawned += AddTrackObject;
            spawnManager.OnTrackObjectDestroyed += RemoveTrackObject;
        }

        private void MoveTrack(float distance)
        {
            foreach (var trackObject in _trackObjects)
            {
                trackObject.Move(-distance);
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