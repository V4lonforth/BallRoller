using UnityEngine;

namespace Scripts.Track
{
    public interface ITrackObject
    {
        public GameObject GameObject { get; }
        
        void Move(float distance);
        bool CheckFinish();
    }
}