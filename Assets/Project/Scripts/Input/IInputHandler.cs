using UnityEngine;

namespace Scripts.Input
{
    /// <summary>
    /// Base interface for classes that handle input
    /// </summary>
    public interface IInputHandler
    {
        bool HandleTouch(int inputId, Vector2 inputPosition, TouchPhase inputPhase);
    }
}