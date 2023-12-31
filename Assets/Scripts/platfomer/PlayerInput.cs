using System;
using UnityEngine;

namespace Platformer
{
    public class PlayerInput : MonoBehaviour
    {
        public Action playerJump;
        public Action playerAttack;

        private PlayerPlatformerInputSystem _inputSystem;

        public Vector2 moveInput => new(_inputSystem.Player.Move.ReadValue<float>(), 0f);

        private void Awake()
        {
            _inputSystem = new PlayerPlatformerInputSystem();
            _inputSystem.Player.Jump.performed += _ => playerJump?.Invoke();
            _inputSystem.Player.Attack.performed += _ => playerAttack?.Invoke();
        }

        private void OnEnable()
        {
            _inputSystem.Enable();
        }

        private void OnDisable()
        {
            _inputSystem.Disable();
        }
    }
}