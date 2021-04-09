using UnityEngine;

namespace Scripts.Input
{
    /// <summary>
    /// Basic input handling
    /// </summary>
    public abstract class DefaultInputHandler : MonoBehaviour, IInputHandler
    {
        private int _inputId;
        private bool _isPressed;

        protected void Awake()
        {
            InputManager.Instance.AddInputHandler(this);
        }
        protected void OnDestroy()
        {
            InputManager.Instance.RemoveInputHandler(this);
        }

        public bool HandleTouch(int inputId, Vector2 inputPosition, TouchPhase inputPhase)
        {
            switch (inputPhase)
            {
                case TouchPhase.Began:
                    return Press(inputId, inputPosition);
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    return Hold(inputId, inputPosition);
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    return Release(inputId, inputPosition);
                default:
                    return false;
            }
        }

        private bool Press(int inputId, Vector2 inputPosition)
        {
            if (_isPressed) return false;
            
            _isPressed = true;
            _inputId = inputId;
            
            HandlePress(inputPosition);
            return true;
        }

        private bool Hold(int inputId, Vector2 inputPosition)
        {
            if (!_isPressed || _inputId != inputId) return false;
            
            HandleHold(inputPosition);
            return true;
        }

        private bool Release(int inputId, Vector2 inputPosition)
        {
            if (!_isPressed || _inputId != inputId) return false;
            
            _isPressed = false;
            
            HandleRelease(inputPosition);
            return true;
        }

        protected abstract void HandlePress(Vector2 inputPosition);
        protected abstract void HandleHold(Vector2 inputPosition);
        protected abstract void HandleRelease(Vector2 inputPosition);
    }
}