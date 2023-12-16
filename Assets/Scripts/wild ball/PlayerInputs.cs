using UnityEngine;

namespace WildBall
{
    public class PlayerInputs : MonoBehaviour
    {
        public Vector2 inputMovement;

        private WildBallInputSystem _inputActions;
        private Player _player;
        private Vector3 _moveInput;


        public bool HasMoveInput() => _moveInput.magnitude > 0.1f;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _inputActions = new WildBallInputSystem();
        }

        private void OnEnable()
        {
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Disable();
        }

        private void Update()
        {
            inputMovement = _inputActions.Ball.Move.ReadValue<Vector2>();

            Movement();
        }

        private void Movement()
        {
            _moveInput = new Vector3(inputMovement.x, inputMovement.y, 0f);

            if (HasMoveInput()) { _player.SetMoveInput(_moveInput); }
            else { _player.SetMoveInput(Vector3.zero); }
        }

    }
}