using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravySphere : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("trigger enter!");
        if(other.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("trigger exit!");
        if (other.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.useGravity = true;
        }
    }
}
