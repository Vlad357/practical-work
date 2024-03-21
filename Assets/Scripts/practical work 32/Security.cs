using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Security : MonoBehaviour
{
    public Zone zone;
    private NavMeshAgent _agent;
    private float _stopDistance = 3;
    private GameObject _visitor;
    
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_visitor)
        {
            _agent.destination = _visitor.transform.position;
            
            if (_agent.remainingDistance <= _stopDistance)
            {
                SetRandomVisitorInZone();
            }
        }
        else
        {
            SetRandomVisitorInZone();
        }
    }

    private void SetRandomVisitorInZone()
    {
        _visitor = zone.GetRandomVisitor();
        if (!_visitor)
        {
            _agent.destination = transform.position;
        }
    }
}
