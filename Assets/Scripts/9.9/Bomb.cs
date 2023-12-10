using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField] private float _timerBoom = 5f;
    [SerializeField] private float _radius = 5f;
    [SerializeField] private float _power = 1f;

    [SerializeField] private LayerMask _layer;

    private void Update()
    {
        _timerBoom -= Time.deltaTime;

        if (_timerBoom <= 0)
        {
            _timerBoom = 5;
            DetonateABomb();
        }
    }

    private void DetonateABomb()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, _radius, _layer);

        if(targets.Length > 0)
        {
            foreach(Collider target in targets)
            {
                if(target.TryGetComponent(out Rigidbody rigidbody))
                {
                    float distace = Vector3.Distance(target.transform.position, transform.position);
                    rigidbody.AddForce((target.transform.position - transform.position) * _power * (_radius - distace), ForceMode.Impulse);
                }
            }
        }
    }
}
