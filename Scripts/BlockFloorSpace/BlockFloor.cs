using UnityEngine;

namespace ManyBlocks.Scripts.BlockFloorSpace
{
    public class BlockFloor : MonoBehaviour
    {
        [SerializeField] private Material[] materialList;

        public void ChangeMaterial(Vector3Int pos)
        {
            gameObject.GetComponent<MeshRenderer>().material =
                materialList[pos.GetManhattanFromOrigin().ModPositively(materialList.Length)];
        }
    }
}