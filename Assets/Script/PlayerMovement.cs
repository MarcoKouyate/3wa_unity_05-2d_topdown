using UnityEngine;

namespace TopDown {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Show In Inspector

        public MovementStateEnum state;
        [SerializeField] private float _walkingSpeed;
        [SerializeField] private float _runningSpeed;

        #endregion


        #region Properties

        public Rigidbody2D Rigidbody{ get => _rigidbody; }
        public float WalkingSpeed { get => _walkingSpeed; }
        public float RunningSpeed { get => _runningSpeed; }

        #endregion


        #region State Machine
        public void TransitionTo(MovementState movementState)
        {
            _movementState.OnExit();
            SetMovementState(movementState);
        }

        private void SetMovementState(MovementState movementState)
        {
            _movementState = movementState;
            movementState.OnEnter();
        }
        #endregion


        #region Unity Cycle
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            SetMovementState(new MovementStateIdle(this));
        }

        private void Update()
        {
            _movementState.OnUpdate();
        }

        private void FixedUpdate()
        {
            _movementState.OnFixedUpdate();
        }
        #endregion


        #region Private Variables
        private MovementState _movementState;
        private Rigidbody2D _rigidbody;
        #endregion
    }
}
