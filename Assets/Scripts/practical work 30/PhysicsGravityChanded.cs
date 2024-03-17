using System;
using UnityEngine;

namespace practical_work_30
{
    public class PhysicsGravityChanded : MonoBehaviour
    {
        public GameplayInputs gameplayInputs;

        [SerializeField]private float graviyFactor = 1f;

        private void Start()
        {
            gameplayInputs.OnGravitationRecived += GameplayInputsOnGravitationRecived;
        }

        private void GameplayInputsOnGravitationRecived(Vector2 delta)
        {
            delta *= graviyFactor;
            Vector3 gravityDelta = new Vector3(delta.x, Physics.gravity.y, delta.y);
            Physics.gravity = gravityDelta;
        }
    }
}