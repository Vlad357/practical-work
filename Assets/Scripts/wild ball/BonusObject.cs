using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObject : MonoBehaviour
{
    public GameObject bonusEffect;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(bonusEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
