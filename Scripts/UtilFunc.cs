using UnityEngine;

namespace ManyBlocks.Scripts
{
    public static class UtilFunc
    {
        public static void DestroyAllChildren(this Transform parent)
        {
            for (var i = parent.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(parent.GetChild(i).gameObject);
            }
        }
        
        public static void DestroyImmediateAllChildren(this Transform parent)
        {
            for (var i = parent.childCount - 1; i >= 0; i--)
            {
                Object.DestroyImmediate(parent.GetChild(i).gameObject);
            }
        }

        public static int GetManhattanFromOrigin(this Vector3Int vector)
        {
            return vector.x + vector.y + vector.z;
        }

        public static int ModPositively(this int number, int divisor)
        {
            int result = number % divisor;
            if (result < 0) result += divisor;
            return result;
        }
    }
}