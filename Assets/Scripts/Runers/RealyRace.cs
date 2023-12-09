using System.Collections.Generic;
using UnityEngine;

namespace Runers
{
    public class RealyRace : MonoBehaviour
    {
        public static RealyRace Instance;

        public Transform targetPoint;

        [SerializeField]private List<Transform> _points;
        private int _currentPointNumber = 0;

        public void SetNextPoint()
        {
            if (_currentPointNumber == _points.Count - 1)
            {
                _currentPointNumber = 0;
                targetPoint = _points[_currentPointNumber];
                return;
            }
            _currentPointNumber++;
            targetPoint = _points[_currentPointNumber];
        }


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }
    }
}
