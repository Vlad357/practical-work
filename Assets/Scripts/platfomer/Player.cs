using System.Collections;
using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : Entity
    {
        public Transform ground;
        public LayerMask groundLayer;
        public float groundDistance = 0.5f;

        private bool _isGrounded;
        private float _speed = 3;
        private float _jumpForce = 9;

        private int _coin;

        private PlayerInput _input;
        private Rigidbody2D _rigidbody;

        private PlayerUI _playerUI;
        private LosePanel _losePanel;

        public int Coin
        {
            get => _coin;
            set
            {
                _coin = value;
                _playerUI?.SetCoins(value);
            }
        }

        public override float CurrentHealth { 
            get => base.CurrentHealth; 
            set
            {
                _currentHealth = value;
                _playerUI?.SetHealth(_currentHealth, _maxHealth);
            }
        }

        protected override void Death()
        {
            base.Death();
            _losePanel?.Show();
        }

        private new void Start()
        {
            base.Start();
            _input = GetComponent<PlayerInput>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerUI = FindObjectOfType<PlayerUI>();
            _losePanel = FindObjectOfType<LosePanel>();

            _input.playerJump = Jump;
            _input.playerAttack = Attack;

            _playerUI?.SetHealth(_currentHealth, _maxHealth);
        }
        private void FixedUpdate()
        {
            Movement(_input.Move);
        }

        private void Jump()
        {
            _isGrounded = Physics2D.OverlapCircle(ground.position, groundDistance, groundLayer);
            if (_isGrounded)
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }

        private void Movement(Vector2 directionMove)
        {
            Idle();
            if (directionMove.magnitude > 0.1f)
            {
                Run();
                _animator.SetFloat(PlayerAnimatorParameters.DIRECTIONAXIS, directionMove.x);
            }

            Vector2 direction = directionMove * _speed;
            _rigidbody.velocity = new(direction.x, _rigidbody.velocity.y);
        }
    }
}