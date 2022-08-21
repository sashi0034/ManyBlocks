using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using NormalAnimal.Scripts.Foods;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;


namespace NormalAnimal.Scripts
{
    [Serializable]
    struct FoodPrefabList
    {
        [SerializeField] private FoodObjectBase[] list;

        public FoodObjectBase GetRandom()
        {
            int random = UnityEngine.Random.Range(0, list.Length);
            return list[random];
        }
    }
    
    public class FoodManager : MonoBehaviour
    {
        [SerializeField] private FoodPrefabList foodPrefabs;
        [SerializeField] private float startPosY = 15;
        [SerializeField] private float fieldSize = 10f;
        [SerializeField] private float bottomY = -20f;

        public float BottomY => bottomY; 

        private void Start()
        {
            birthFoodsAsync();
        }

        private void Update()
        {}

        private async UniTask birthFoodsAsync()
        {
            while (gameObject!=null)
            {
                var food = Instantiate(foodPrefabs.GetRandom(), this.gameObject.transform);
                
                food.Init(this);
                float x = UnityEngine.Random.Range(-fieldSize, fieldSize);
                float z = UnityEngine.Random.Range(-fieldSize, fieldSize);
                food.transform.position = new Vector3(x, startPosY, z);
                
                await UniTask.Delay(1000);
            }
        } 
    }
}


