using UnityEngine;

namespace Scripts.Utils
{
    /// <summary>
    /// Base class for MonoBehaviour singletons
    /// </summary>
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = (T)FindObjectOfType(typeof(T));

                if (_instance != null) return _instance;
                var gameObject = new GameObject(typeof(T).Name);
                _instance = gameObject.AddComponent(typeof(T)) as T;

                return _instance;
            }
        }
    }
}