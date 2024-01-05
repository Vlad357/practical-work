using Cinemachine;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : Entity
    {
        public Vector2 positionOnNextScene;

        private int _coin;

        private PlayerInput _input;
        private Statistic _statistic;
        private PlayerUI _playerUI;
        private GameOverPanel _gameOverPanel;

        public Statistic Statistic
        {
            get => _statistic;
            set
            {
                _statistic = value;
                Coin = _statistic.coins;
            }
        }

        public int Coin
        {
            get => _coin;
            set
            {
                _coin = value;
                _playerUI?.SetCoins(value);
                _statistic.coins = value;
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

        public override void SetDamage(float damage)
        {
            base.SetDamage(damage);
            if(damage > 0)
            {
                _statistic.damageDone += damage;
            }
        }

        protected override void Death()
        {
            base.Death();
            _gameOverPanel.Show();
            _gameOverPanel.PlayerStatistic = _statistic;
        }

        private void Init()
        {
            FindAnyObjectByType<CinemachineVirtualCamera>().Follow = transform;
            _playerUI = FindObjectOfType<PlayerUI>();
            _gameOverPanel = FindObjectOfType<GameOverPanel>();

            _input = GetComponent<PlayerInput>();

            _input.playerJump = Jump;
            _input.playerAttack = Attack;

            _playerUI?.SetHealth(_currentHealth, _maxHealth);
            _playerUI?.SetCoins(Coin);

            _onAttack += () => _statistic.damageDone += damage;
        }

        private new void Start()
        {
            base.Start();
            
            Init();
        }
        private void FixedUpdate()
        {
            Movement(_input.moveInput);
        }
    }
}