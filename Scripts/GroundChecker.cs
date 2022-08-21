using ManyBlocks.Scripts;
using UnityEngine;

namespace NormalAnimal.Scripts.Player
{
    public class GroundChecker
    {
        private readonly Transform _ownerTransform;


        public bool IsGrounded { get; private set; } = false;

        private readonly float _localVerticalRayStart;
        private readonly float _verticalRayLength;
        
        
        public GroundChecker(Transform ownerTransform, BoxCollider ownerCollider)
        {
            Debug.Assert(ownerCollider!=null);

            _ownerTransform = ownerTransform;

            _localVerticalRayStart = ownerCollider.center.y;
            _verticalRayLength = ownerCollider.size.y;
        }

        public void UpdateChecking()
        {
            IsGrounded =
                isGrounded(out var hit) &&
                hit.collider.gameObject.TryGetComponent<Ground>(out _);
        }
        
        
        private bool isGrounded(out RaycastHit hit)
        {
            var rayStartPos = _ownerTransform.position + Vector3.up * _localVerticalRayStart;
            var ray = new Ray(rayStartPos, _ownerTransform.up * -1);
            float rayDistance = _verticalRayLength;
            Debug.DrawRay(ray.origin, ray.direction * rayDistance);

            return (Physics.Raycast(ray, out hit, rayDistance));
        }
    }
}