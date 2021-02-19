using UnityEngine;

namespace TopDown {
    [RequireComponent(typeof(PlayerMovementController))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Show In Inspector

        public MovementStateEnum state;

        [SerializeField] private float _dashDuration;
        [SerializeField] private MovementState _startingState;
        [SerializeField] private PlayerAnimation _animation;

        #endregion


        #region Properties

        public float DashDuration { get => _dashDuration; }
        public PlayerAnimation Animation { get => _animation; }
        public PlayerMovementController Controller { get => _controller; }

        #endregion


        #region State Machine
        public void TransitionTo(MovementState movementState)
        {
            _movementState.OnExit(this);
            SetMovementState(movementState);
        }

        private void SetMovementState(MovementState movementState)
        {
            _movementState = movementState;
            movementState.OnEnter(this);
        }
        #endregion


        #region Unity Cycle
        private void Awake()
        {
            SetMovementState(_startingState);
            _controller = GetComponent<PlayerMovementController>();
        }

        private void Update()
        {
            _movementState.OnUpdate(this);
        }

        private void FixedUpdate()
        {
            _movementState.OnFixedUpdate(this);
        }
        #endregion


        #region Private Variables
        private MovementState _movementState;
        private PlayerMovementController _controller;
        #endregion
    }
}
