using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour
{
    public UnityEvent onButtonPressed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onButtonPressed.Invoke();
        }
    }
}
