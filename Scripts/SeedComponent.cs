using System;
using UnityEngine;

namespace ManyBlocks.Scripts
{
    [Serializable]
    public class SeedComponent<T> where T : MonoBehaviour
    {
        [SerializeField] private T prefab;
        public GameObject Birth(Transform parent)
        {
            return GameObject.Instantiate(prefab.gameObject, parent);
        }
    }
}