using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall
{
    public class finalTrigger : MonoBehaviour
    {
        public GameObject winText;

        public List<ParticleSystem> particles;
        private void OnTriggerEnter(Collider other)
        {
            winText.SetActive(true);

            foreach(ParticleSystem particle in particles)
            {
                particle.Play();
            }
        }
    }
}
