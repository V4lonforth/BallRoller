using UnityEngine;

namespace Scripts.Track
{
    public class StaticTrackObject : MonoBehaviour, ITrackObject
    {
        public void Move(float distance)
        {
            transform.position += TrackParameters.Instance.forwardMovementDirection * distance;
        }
    }
}