using UnityEngine;

namespace Runers
{
    public class Point : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Runer runer))
            {
                RealyRace.Instance.SetNextPoint();
            }
        }
    }
}
