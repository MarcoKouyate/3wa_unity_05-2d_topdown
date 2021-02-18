using UnityEngine;

namespace TopDown {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Show In Inspector

        public MovementStateEnum state;
        [SerializeField] private float _walkingSpeed;
        [SerializeField] private float _runningSpeed;
        [SerializeField] private float _dashSpeed;
        [SerializeField] private float _dashDuration;
        [SerializeField] MovementState _startingState;

        #endregion


        #region Properties

        public Rigidbody2D Rigidbody{ get => _rigidbody; }
        public float WalkingSpeed { get => _walkingSpeed; }
        public float RunningSpeed { get => _runningSpeed; }
        public float DashSpeed { get => _dashSpeed; }
        public float DashDuration { get => _dashDuration; }

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
            _rigidbody = GetComponent<Rigidbody2D>();
            SetMovementState(_startingState);
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

        public void MoveTowardsDirection(Vector2 direction, float speed)
        {
            Vector2 velocity = direction * speed * Time.fixedDeltaTime * 100;
           _rigidbody.velocity = velocity;
        }


        #region Private Variables
        private MovementState _movementState;
        private Rigidbody2D _rigidbody;
        #endregion
    }
}
