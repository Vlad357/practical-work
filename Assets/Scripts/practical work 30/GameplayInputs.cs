using System;
using UnityEngine;

namespace practical_work_30
{
    public class GameplayInputs : MonoBehaviour
    {
        public event Action<Vector2> OnGravitationRecived;
        
        private BallInputAction _input;
        private BallMovementInput _ballInput;

        private void Start()
        {
            _input = new BallInputAction();

            _ballInput = new BallMovementInput(_input);
            _ballInput.PhysicGravitationRecived += OnPhysicGravitationRecived;
            
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void InitBallMovement(BallInputAction input)
        {
            _ballInput = new BallMovementInput(input);
            _ballInput.PhysicGravitationRecived += OnPhysicGravitationRecived;
        }
        
        private void OnPhysicGravitationRecived(Vector2 delta)
        {
            OnGravitationRecived?.Invoke(delta);
        }
    }
}