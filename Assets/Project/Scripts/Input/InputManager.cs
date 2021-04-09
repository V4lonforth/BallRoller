using System.Collections.Generic;
using System.Linq;
using Scripts.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.Input
{
    /// <summary>
    /// Class that manages every input handler
    /// </summary>
    public class InputManager : Singleton<InputManager>
    {
        private EventSystem _eventSystem;

        private readonly List<IInputHandler> _inputHandlers = new List<IInputHandler>();

        private void Awake()
        {
            _eventSystem = EventSystem.current;
        }
    
        private void Update()
        {
            foreach (var touch in UnityEngine.Input.touches)
            {
                if (touch.phase != TouchPhase.Began || _eventSystem == null || !_eventSystem.IsPointerOverGameObject(touch.fingerId))
                    HandleTouch(touch.fingerId, touch.position, touch.phase);
            }

            if (UnityEngine.Input.touchCount != 0) return;
            
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                if (_eventSystem == null || !_eventSystem.IsPointerOverGameObject())
                    HandleTouch(-1, UnityEngine.Input.mousePosition, TouchPhase.Began);
            }
            if (UnityEngine.Input.GetMouseButton(0))
                HandleTouch(-1, UnityEngine.Input.mousePosition, TouchPhase.Moved);
            if (UnityEngine.Input.GetMouseButtonUp(0))
                HandleTouch(-1, UnityEngine.Input.mousePosition, TouchPhase.Ended);
        }

        private bool HandleTouch(int touchId, Vector2 touchPosition, TouchPhase touchPhase)
        {
            return _inputHandlers.Any(inputHandler => inputHandler.HandleTouch(touchId, touchPosition, touchPhase));
        }

        public void AddInputHandler(IInputHandler inputHandler)
        {
            _inputHandlers.Add(inputHandler);
        }
        
        public bool RemoveInputHandler(IInputHandler inputHandler)
        {
            return _inputHandlers.Remove(inputHandler);
        }
    }
}
