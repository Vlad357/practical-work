using System.Collections;
using UnityEngine;

namespace Runers
{
    public class Runer : MonoBehaviour
    {

        public float speed;
        public Marker marker;

        [SerializeField]private bool _isRuner;
        [SerializeField]private Transform _targetPoint;

        public bool IsRuner
        {
            get
            {
                return _isRuner;
            }

            set
            {
                if (_isRuner != value)
                {
                    _isRuner = value;
                    TargetPoint = RealyRace.Instance.targetPoint;
                }
            }
        }

        public Transform TargetPoint { 
            get { return _targetPoint; } 
            set {
                RotateToPoint(value.position);
                _targetPoint = value; 
            }
        }

        public void RotateToPoint(Vector3 target)
        {
            transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
        }

        public IEnumerator TurnOnRuner()
        {
            yield return new WaitForSeconds(0.5f);
            IsRuner = true;
        }
        public IEnumerator TurnOffRuner()
        {
            yield return new WaitForSeconds(0.5f);
            IsRuner = false;
        }

        private void Update()
        {
            if(_isRuner)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, speed * Time.deltaTime);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Runer runer) && _isRuner)
            {
                StartCoroutine(runer.TurnOnRuner());
                StartCoroutine(TurnOffRuner());
                marker.SetRuner(runer);
            }
        }

    }
}
