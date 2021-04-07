using UnityEngine;

namespace Scripts.Input
{
    public interface IInputHandler
    {
        bool HandleTouch(int inputId, Vector2 inputPosition, TouchPhase inputPhase);
    }
}