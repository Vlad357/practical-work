using UnityEngine;

namespace WildBall
{
    public class ObstacleAnimationController : MonoBehaviour
    {
        public int minValue;
        public int maxValue;
        private Animator _animator;

        public void SwitchAnimtaion()
        {
            _animator.SetInteger("random animation", Random.Range(minValue, maxValue + 1));
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
    }
}