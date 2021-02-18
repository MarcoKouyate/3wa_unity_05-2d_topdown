using UnityEngine;

namespace TopDown {
    public class MovementStateDash : MovementState
    {

        #region Constructor
        public MovementStateDash(PlayerMovement playerMovement) : base(playerMovement) { }
        #endregion


        #region State Cycle
        public override void OnEnter()
        {
            _playerMovement.state = MovementStateEnum.Dash;
            _endTime = Time.time + _playerMovement.DashDuration;
            _speed = _playerMovement.DashSpeed;
        }


        public override void OnUpdate()
        {
            _hasReleasedButton |= Input.GetButtonUp("Dash");

            if (Time.time > _endTime)
            {
                Transition();
            }
        }

        public override void OnFixedUpdate()
        {
            _playerMovement.Rigidbody.velocity = _playerMovement.rotation * _speed;
        }


        public override void OnExit()
        {
            _playerMovement.Rigidbody.velocity = Vector2.zero;
        }
        #endregion


        #region Transitions
        private void Transition()
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                if(_hasReleasedButton)
                {
                    _playerMovement.TransitionTo(new MovementStateWalk(_playerMovement));
                } else
                {
                    _playerMovement.TransitionTo(new MovementStateSprint(_playerMovement));
                }
            } else
            {
                _playerMovement.TransitionTo(new MovementStateIdle(_playerMovement));
            }
        }
        #endregion


        #region Private Variables
        private float _endTime;
        private float _speed;
        private bool _hasReleasedButton;
        #endregion

    }
}
