using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


namespace WildBall
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerInputs))]
    public class Player : MonoBehaviour
    {
        public GameObject deadEffect;

        private Rigidbody _rigidbody;

        private bool _canMove = true;
        private bool _breacking = false;
        private float _speed = 200f;
        private float _breacingTime = 0.1f;
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
            if (relativeVelocity.magnitude < 0.1f && _cameraRelativeInput.magnitude > 0.1f)
            {
                _canMove = false;
            }

            _cameraRelativeInput = relativeVelocity;
        }

        public void Lose()
        {
            Instantiate(deadEffect, transform.position, transform.rotation);
            GameManager.Instance.LoseEvent();
            Destroy(gameObject);
        }

        private IEnumerator Breack()
        {
            yield return new WaitForSeconds(_breacingTime);
            _rigidbody.velocity = Vector3.zero;
            _canMove = true;
            _breacking = false;
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
            if(_cameraRelativeInput.magnitude > 0.1f)
            {
                _rigidbody.velocity = _cameraRelativeInput * _speed * Time.fixedDeltaTime;

            }
            else if (!_canMove && !_breacking)
            {
                _breacking = true;
                StartCoroutine(Breack());
            }
        }
    }

}
