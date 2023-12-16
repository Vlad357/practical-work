using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace WildBall
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerInput))]
    public class Player : MonoBehaviour
    {

        private Rigidbody _rigidbody;

        private float _speed = 200f;
        private Vector3 _moveInput;
        private Vector3 _cameraRelativeInput;

        public void SetMoveInput(Vector2 inputMovement)
        {
            _moveInput = inputMovement;

            var forward = Camera.main.transform.TransformDirection(Vector3.forward);
            forward.y = 0;
            forward = forward.normalized;

            var right = new Vector3(forward.z, 0, -forward.x);
            var relativeVelocity = _moveInput.x * right + _moveInput.y * forward;

            if (relativeVelocity.magnitude > 1) { relativeVelocity.Normalize(); }

            _cameraRelativeInput = relativeVelocity;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rigidbody.velocity = _cameraRelativeInput * _speed * Time.fixedDeltaTime;
        }
    }

}
