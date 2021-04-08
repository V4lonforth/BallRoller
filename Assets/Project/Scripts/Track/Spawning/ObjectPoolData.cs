using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Track.Spawning
{
    [Serializable]
    public class ObjectPoolData
    {
        public GameObject prefab;
        public int minPoolSize;

        [NonSerialized] public readonly List<GameObject> instantiatedObjects = new List<GameObject>();
    }
}