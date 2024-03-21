using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Zone : MonoBehaviour
{
    private string visitorsTag = "Visitor";
    [SerializeField]private List<GameObject> visitorsOnZone;

    public GameObject GetRandomVisitor()
    {
        if (visitorsOnZone.Count == 0) return null;
        
        int randomId = Random.Range(0, visitorsOnZone.Count);
        return visitorsOnZone[randomId];
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(visitorsTag))
        {
            visitorsOnZone.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(visitorsTag))
        {
            visitorsOnZone.Remove(other.gameObject);
        }
    }
}
