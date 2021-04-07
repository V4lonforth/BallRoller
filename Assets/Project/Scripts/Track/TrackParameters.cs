using Scripts.Utils;
using UnityEngine;

namespace Scripts.Track
{
    public class TrackParameters : Singleton<TrackParameters>
    {
        public Vector3 forwardMovementDirection = Vector3.forward;
        public Vector3 horizontalMovementDirection = Vector3.right;
        public float trackWidth;
    }
}