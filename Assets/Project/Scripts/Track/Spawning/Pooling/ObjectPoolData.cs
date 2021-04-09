using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Track.Spawning.Pooling
{
    /// <summary>
    /// Class containing object pool data
    /// </summary>
    [Serializable]
    public class ObjectPoolData
    {
        public GameObject prefab;
        public int minPoolSize;

        [NonSerialized] public readonly List<GameObject> InstantiatedObjects = new List<GameObject>();
    }
}