namespace NormalAnimal.Scripts.Foods
{
    public class Pumpkin : FoodObjectBase
    {
        private void Update()
        {
            if (ParentalManager==null) return;

            if (gameObject.transform.position.y < ParentalManager.BottomY)
            {
                Destroy(gameObject);
                return;
            }
        }
    }
}