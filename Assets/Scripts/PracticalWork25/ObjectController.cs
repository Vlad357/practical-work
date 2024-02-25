using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float impulseStrength = 1f;
    
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Scaler()
    {
        transform.localScale += Vector3.one;
    }

    public void AddForseObject()
    {
        _rigidbody.AddForce(Vector3.up * impulseStrength);
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
