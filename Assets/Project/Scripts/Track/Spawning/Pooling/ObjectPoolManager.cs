using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Track.Spawning.Pooling
{
    /// <summary>
    /// Class that manages pooling objects
    /// </summary>
    public class ObjectPoolManager : MonoBehaviour
    {
        [SerializeField] private Transform poolTransformParent;
        [SerializeField] private List<ObjectPoolData> poolDataList;

        private void Awake()
        {
            foreach (var poolData in poolDataList)
            {
                for (var i = 0; i < poolData.minPoolSize; i++)
                {
                    AddObjectToPool(poolData);
                }
            }
        }

        private void AddObjectToPool(ObjectPoolData poolData)
        {
            AddToPool(poolData, Instantiate(poolData.prefab));
        }

        private GameObject GetFromPool(ObjectPoolData poolData)
        {
            var obj = poolData.InstantiatedObjects.Last();
            poolData.InstantiatedObjects.RemoveAt(poolData.InstantiatedObjects.Count - 1);
            obj.SetActive(true);
            return obj;
        }

        private void AddToPool(ObjectPoolData poolData, GameObject obj)
        {
            poolData.InstantiatedObjects.Add(obj);
            obj.transform.SetParent(poolTransformParent);
            obj.SetActive(false);
        }

        public GameObject CreateObject(GameObject prefab)
        {
            var poolData = FindPool(prefab);
            if (poolData == null) return Instantiate(prefab);
            
            if (poolData.InstantiatedObjects.Count == 0)
                AddObjectToPool(poolData);
            return GetFromPool(poolData);
        }

        public void DestroyObject(GameObject obj)
        {
            var poolData = FindPool(obj);
            if (poolData != null)
            {
                AddToPool(poolData, obj);
            }
            else
            {
                Destroy(obj);
            }
        }

        private ObjectPoolData FindPool(GameObject obj)
        {
            return poolDataList.Find(p => obj.CompareTag(p.prefab.tag));
        }
    }
}