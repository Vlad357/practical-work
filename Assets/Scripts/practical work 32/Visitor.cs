using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace practical_work_32
{
    public class Visitor : MonoBehaviour
    {
        private readonly string _triggerTag = "Trigger";
        private NavMeshAgent _agent;
        private Vector3 targetPosition;
        private float _stopDistance = 3;
    
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (_agent.remainingDistance <= _stopDistance)
            {
                GoToRandomTrigger();
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void GoToRandomTrigger()
        {
            List<GameObject> list = GameObject.FindGameObjectsWithTag(_triggerTag).ToList();
            int randomId = Random.Range(0, list.Count);
            targetPosition = list[randomId].transform.position;

            _agent.destination = targetPosition;
        }
    }
}
