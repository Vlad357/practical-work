using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace practical_work_30
{
    public class BallMovementInput
    {
        public event Action<Vector2> PhysicGravitationRecived;
        
        private readonly BallInputAction _input;

        public BallMovementInput(BallInputAction input)
        {
            this._input = input;

            InitInputAction(_input);
        }

        private void InitInputAction(BallInputAction input)
        {
            input.Ball.Delta.performed += DeltaOnperformed;
        }

        private void DeltaOnperformed(InputAction.CallbackContext context)
        {
            Vector2 delta = context.ReadValue<Vector2>();
            PhysicGravitationRecived?.Invoke(delta);
        }
    }
}