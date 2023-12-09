using UnityEngine;

namespace Runers
{
    public class Marker : MonoBehaviour
    {
        public void SetRuner(Runer runer)
        {
            transform.SetParent(runer.transform, false);
            runer.marker = this;
        }
    }
}
