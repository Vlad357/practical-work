using System.Collections;
using UnityEngine;

namespace Platfomer
{
    [RequireComponent(typeof(Animator))]
    public class Entity : MonoBehaviour
    {
        public Transform attackPoint;
        public LayerMask enemyLayer;
        public float attackRange = 1f;
        public float attackRate = 2f;
        public float damage = 20f;
        public bool attackReady = true;

        protected States _state = States.Idle;

        protected float _currentHealth;
        protected float _maxHealth = 100f;

        protected Animator _animator;

        public virtual float CurrentHealth
        {
            get
            {
                return _currentHealth;
            }
            set
            {
                _currentHealth = value;
            }
        }

        public virtual void SetDamage(float damage)
        {
            if (damage > 0)
            {
                CurrentHealth -= damage;
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
                }

                attackReady = false;
                StartCoroutine(AttackCoolDown());
            }
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
