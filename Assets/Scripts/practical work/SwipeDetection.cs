using UnityEngine;
using UnityEngine.InputSystem;

namespace practical_work
{
    public class SwipeDetection
    {
        private TouchInput _input;

        private Vector2 _touchStartPosition;
        private Vector2 _touchEndPosition;
        private readonly float _swipeThresholdX = 100f;
        private readonly float _swipeThresholdY = 50f;

        public SwipeDetection(TouchInput input)
        {
            this._input = input;
        
            _input.ScreenInput.Touch.started += OnTouchStart;
            _input.ScreenInput.Touch.canceled += OnTouchEnd;
        }

        public void OnTouchStart(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _touchStartPosition = _input.ScreenInput.TouchPosition.ReadValue<Vector2>();
            }
        }
 
        public void OnTouchEnd(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                _touchEndPosition = _input.ScreenInput.TouchPosition.ReadValue<Vector2>();
                DetectSwipe();
            }
        }
 
        private void DetectSwipe()
        {
            float swipeX = _touchEndPosition.x - _touchStartPosition.x;
            float swipeY = _touchEndPosition.y - _touchStartPosition.y;
 
            if (Mathf.Abs(swipeX) >= _swipeThresholdX && Mathf.Abs(swipeY) <= _swipeThresholdY && swipeX > 0)
            {
                Debug.Log("Swipe to the right");
            }
        }
    }
}
