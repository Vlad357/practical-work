using System;
using System.Collections;
using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Animator))]
    public class Entity : MonoBehaviour
    {
        public Transform attackPoint;
        public LayerMask enemyLayer;
        public LayerMask groundLayer;
        public float attackRange = 1f;
        public float attackRate = 2f;
        public float damage = 20f;
        public bool attackReady = true;

        protected States _state = States.Idle;

        protected float _currentHealth;
        protected float _maxHealth = 100f;

        protected float _speed = 4.5f;
        protected float _jumpForce = 15;
        protected float _groundDistance = 0.1f;

        protected bool _isGrounded = true;

        protected Action _onAttack;

        protected Animator _animator;
        protected Rigidbody2D _rigidbody;

        public virtual float CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

        public virtual void SetDamage(float damage)
        {
            if (damage > 0)
            {
                CurrentHealth -= damage;
                //TODO: queue damage animation
                if (_currentHealth <= 0)
                {
                    Death();
                }
            }
        }

        protected void Attack()
        {
            if (attackReady && _state != States.Death)
            {
                AnimationAttack();

                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponentInParent<Entity>().SetDamage(damage);
                    _onAttack?.Invoke();
                }

                attackReady = false;
                StartCoroutine(AttackCoolDown());
            }
        }

        protected void Jump()
        {
            _isGrounded = Physics2D.Raycast(transform.position, Vector3.down, _groundDistance, groundLayer);
            if (_isGrounded)
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
        }

        protected void Movement(Vector2 directionMove)
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

        protected IEnumerator AttackCoolDown()
        {
            yield return new WaitForSeconds(attackRate);
            attackReady = true;
        }

        protected void Idle()
        {
            if (_state != States.Idle)
            {
                _state = States.Idle;
                _animator.SetBool(PlayerAnimatorParameters.IDLE, true);
                _animator.SetBool(PlayerAnimatorParameters.RUN, false);
            }
        }

        protected void Run()
        {
            if (_state != States.Run)
            {
                _state = States.Run;
                _animator.SetBool(PlayerAnimatorParameters.IDLE, false);
                _animator.SetBool(PlayerAnimatorParameters.RUN, true);
            }
        }

        protected virtual void Death()
        {
            _animator.SetBool(PlayerAnimatorParameters.DEATH, true);
            _state = States.Death;
        }

        protected void AnimationAttack()
        {
            _animator.SetTrigger(PlayerAnimatorParameters.ATTACK);
        }

        protected void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();

            CurrentHealth = _maxHealth;
            _animator.SetFloat(PlayerAnimatorParameters.DIRECTIONAXIS, -1);
        }
    }

    public enum States
    {
        Idle,
        Run,
        Death
    }
}
