using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObject : MonoBehaviour
{
    public ParticleSystem bonusEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bonusEffect.Play();
            Destroy(gameObject);
        }
    }
}
