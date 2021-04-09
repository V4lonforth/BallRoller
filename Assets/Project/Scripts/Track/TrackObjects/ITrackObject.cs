using UnityEngine;

namespace Scripts.Track.TrackObjects
{
    /// <summary>
    /// Base interface for objects on track
    /// </summary>
    public interface ITrackObject
    {
        public GameObject GameObject { get; }
        
        void Move(float distance);
        bool CheckFinish();
    }
}