using Scripts.Players;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    /// <summary>
    /// Class that displays current passed distance
    /// </summary>
    public class TrackDistanceDisplay : MonoBehaviour
    {
        [SerializeField] private Text text;
        
        private float _passedDistance;
        
        private void Awake()
        {
            FindObjectOfType<Player>().OnMoved += PassDistance;
        }

        private void PassDistance(float distance)
        {
            _passedDistance += distance;
            DisplayText();
        }

        private void DisplayText()
        {
            text.text = _passedDistance.ToString("0");
        }
    }
}