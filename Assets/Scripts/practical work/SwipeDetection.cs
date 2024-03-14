
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SwipeDetection : MonoBehaviour
{
    private TouchInput _input;

    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;
    private float swipeThresholdX = 100f;
    private float swipeThresholdY = 50f;

    private void Start()
    {
        _input = new TouchInput();
        _input.Enable();
        _input.ScreenInput.Touch.started += OnTouchStart;
        _input.ScreenInput.Touch.canceled += OnTouchEnd;
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    public void OnTouchStart(InputAction.CallbackContext context)
    {
        print(1);
        if (context.started)
        {
            print(2);

            touchStartPosition = _input.ScreenInput.TouchPosition.ReadValue<Vector2>();
        }
    }
 
    public void OnTouchEnd(InputAction.CallbackContext context)
    {
        print(3);

        if (context.canceled)
        {
            print(4);

            touchEndPosition = _input.ScreenInput.TouchPosition.ReadValue<Vector2>();
            DetectSwipe();
        }
    }
 
    private void DetectSwipe()
    {
        float swipeX = touchEndPosition.x - touchStartPosition.x;
        float swipeY = touchEndPosition.y - touchStartPosition.y;
 
        if (Mathf.Abs(swipeX) >= swipeThresholdX && Mathf.Abs(swipeY) <= swipeThresholdY && swipeX > 0)
        {
            Debug.Log("Swipe to the right");
        }
    }
}
