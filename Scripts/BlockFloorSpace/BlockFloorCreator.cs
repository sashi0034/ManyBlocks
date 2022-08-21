using Sirenix.OdinInspector;
using UnityEngine;

namespace ManyBlocks.Scripts.BlockFloorSpace
{
    public class BlockFloorCreator : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private SeedComponent<BlockFloor> blockFloor;
        [SerializeField] private float blockSize = 1f;
        [SerializeField] private int fieldSize = 10;
        [SerializeField] private int numFieldVertical = 2;


        [Button]
        private void clearAll()
        {
            gameObject.transform.DestroyImmediateAllChildren();
        }

        [Button]
        private void createField()
        {
            for (int y=0; y<numFieldVertical; ++y) createFieldPlace(y);
        }

        private void createFieldPlace(int y)
        {
            for (int x = -fieldSize + 1; x <= fieldSize; x += 1)
            {
                for (int z = -fieldSize + 1; z <= fieldSize; z += 1)
                {
                    var block = blockFloor.Birth(gameObject.transform);
                    block.transform.position = new Vector3( x* blockSize, y * blockSize, z * blockSize);
                    block.GetComponent<BlockFloor>().ChangeMaterial(new Vector3Int(x, y, z));
                }
            }
        }
#endif
    }
}