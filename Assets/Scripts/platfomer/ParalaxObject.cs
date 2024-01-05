using UnityEngine;

namespace Platformer
{
    public class ParalaxObject : MonoBehaviour
    {
        public Camera mainCamera;
        public Transform subject;

        private Vector2 startPosition;
        private float startZ;

        private Vector2 Travel => (Vector2)mainCamera.transform.position - startPosition;

        private float DistanceFromSubject => transform.position.z - subject.position.z;
        private float ClippingPlane => (mainCamera.transform.position.z + (DistanceFromSubject > 0 ? mainCamera.farClipPlane : mainCamera.nearClipPlane));
        private float ParalaxFactor => Mathf.Abs(DistanceFromSubject) / ClippingPlane;

        private void Start()
        {
            startPosition = transform.position;
            startZ = transform.position.z;

            subject = FindObjectOfType<Player>().transform;
        }

        private void Update()
        {
            Vector3 newPosition = startPosition + Travel * ParalaxFactor;
            transform.position = new Vector3(newPosition.x, newPosition.y, startZ);
        }
    }
}