using System;
using System.Collections;
using System.Collections.Generic;
using NormalAnimal.Scripts.Foods;
using NormalAnimal.Scripts.Player;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace NormalAnimal.Scripts
{
    interface IPlayer
    {
        
    }

    public class PlayerController : MonoBehaviour, IPlayer
    {
        [SerializeField] private PlayerMove playerMove;

        private Vector3 _startedPosition;


        public readonly AnimHash HashRun = new AnimHash("run");
        public readonly AnimHash HashEat = new AnimHash("eat");
        public readonly AnimHash HashMotionSpeed = new AnimHash("motionSpeed");

        public Animator Animator { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        public BoxCollider Collider { get; private set; }

        private Vector3 _pos => gameObject.transform.position;

        void Start()
        {
            Animator = GetComponentInChildren<Animator>();
            Rigidbody = GetComponent<Rigidbody>();
            Collider = GetComponentInChildren<BoxCollider>();
            playerMove.Init(this);
        }

        void Update()
        {
            // if (Input.GetKey(KeyCode.Space))
            // {
            //     _animator.SetTrigger(HashEat.Code);
            //     Debug.Log("trigger eat.");
            // }

            playerMove.Update();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<FoodObjectBase>(out var food)) onCollideFood(food);
        }

        private void onCollideFood(FoodObjectBase food)
        {
            Destroy(food.gameObject);
            Rigidbody.AddForce(new Vector3(0, 1000, 0));
        }
    }
    
}