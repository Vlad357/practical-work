using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000, ForceMode.Acceleration);
    }
}
