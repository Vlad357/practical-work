using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    public float force = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.AddForce(GetComponent<Rigidbody>().velocity * force, ForceMode.Impulse);
        }
    }
}
