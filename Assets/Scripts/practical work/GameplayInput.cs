using System;
using UnityEngine;
using UnityEngine.UI;

namespace practical_work
{
    public class GameplayInput : MonoBehaviour
    {
        public Image image;
        
        private TouchInput _input;
        private SwipeDetection _swipeDetection;
        private ApproximationDetection _approximationDetection;
        
        private void Start()
        {
            _input = new TouchInput();

            _swipeDetection = new SwipeDetection(_input);
            _approximationDetection = new ApproximationDetection(_input);

            _approximationDetection.DoubleTouch += ApproximationDetectionOnDoubleTouch;
            _approximationDetection.DeltaDoubleTouch += ApproximationDetectionOnDeltaDoubleTouch;
            _approximationDetection.OnApproximationDetect += OnApproximationDetectAction;
            
            _input.Enable();
        }
        
        private void ApproximationDetectionOnDoubleTouch()
        {
            image.color = Color.black;

        }

        private void ApproximationDetectionOnDeltaDoubleTouch()
        {
            image.color = Color.blue;
        }
        
        private void OnApproximationDetectAction()
        {
            image.color = Color.red;
        }

        private void OnDisable()
        {
            _input.Disable();
        }
    }
}