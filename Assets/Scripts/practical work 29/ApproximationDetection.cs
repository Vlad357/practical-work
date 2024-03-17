using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace practical_work
{
    public class ApproximationDetection
    {
        public event Action DoubleTouch;
        public event Action DeltaDoubleTouch;
        public event Action OnApproximationDetect; 
    
        private TouchInput _input;

        private Vector2 _firstTouchStartPosition;
        private Vector2 _secondTouchStartPosition;
        private float _startDistance;
    
        public ApproximationDetection(TouchInput input)
        {
            this._input = input;
        
            _input.Approximation.Touch.started += DoubleTouchPerformed;
            _input.Approximation.Touch.canceled -= DoubleTouchPerformed;
        }

        private void DoubleTouchPerformed(InputAction.CallbackContext context)
        {
            DoubleTouch?.Invoke();
            
            _firstTouchStartPosition = _input.Approximation.EndPositionFirstTouch.ReadValue<Vector2>();
            _secondTouchStartPosition = _input.Approximation.EndPositionSecondTouch.ReadValue<Vector2>();

            _startDistance = Vector2.Distance(_firstTouchStartPosition, _secondTouchStartPosition);
        
            _input.Approximation.Delta.performed += DeltaDoubleTouchPerformed;
        }

        private void DeltaDoubleTouchPerformed(InputAction.CallbackContext context)
        {
            DeltaDoubleTouch?.Invoke();
            DetectApproximation();
        }

        private void DetectApproximation()
        {
            Vector2 firstTouchPosition = _input.Approximation.EndPositionFirstTouch.ReadValue<Vector2>();
            Vector2 secondTouchPosition = _input.Approximation.EndPositionSecondTouch.ReadValue<Vector2>();

            float distance = Vector2.Distance(firstTouchPosition, secondTouchPosition);

            if (distance > _startDistance)
            {
                OnApproximation();
            }
        }

        private void OnApproximation()
        {
            OnApproximationDetect?.Invoke();
        }
    }
}
