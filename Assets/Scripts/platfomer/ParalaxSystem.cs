using UnityEngine;

namespace Platformer
{
    public class ParalaxSystem : MonoBehaviour
    {
        public Transform[] layers;
        public float[] odds;

        private int _count;

        private void Awake()
        {
            _count = layers.Length;
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _count; i++)
            {
                layers[i].position = new Vector3(transform.position.x, transform.position.y, 0f) * odds[i];
            }
        }
    }
}
