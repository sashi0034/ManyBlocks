using UnityEngine;

namespace NormalAnimal.Scripts.Foods
{
    public class FoodObjectBase : MonoBehaviour
    {
        protected FoodManager ParentalManager { get; private set; }

        public void Init(FoodManager manager)
        {
            ParentalManager = manager;
        }
    }
}