using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    private SpringJoint _springJoint;

    private void Start()
    {
        _springJoint = GetComponent<SpringJoint>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            _springJoint.tolerance = 100;
        }
        else if (collision.gameObject.CompareTag("springConnecter"))
        {
            _springJoint.tolerance = 0.25f;
        }
    }
}
