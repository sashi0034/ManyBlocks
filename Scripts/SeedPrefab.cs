using System;
using UnityEngine;

namespace ManyBlocks.Scripts
{
    [Serializable]
    public class SeedPrefab
    {
        [SerializeField] private GameObject prefab;
        public GameObject Birth(Transform parent)
        {
            return GameObject.Instantiate(prefab, parent);
        }
    }
}