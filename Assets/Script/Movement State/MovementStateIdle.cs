using UnityEngine;

namespace TopDown {
    public class MovementStateIdle : MovementState
    {
        #region Constructor

        public MovementStateIdle(PlayerMovement playerMovement) : base(playerMovement){}

        #endregion


        #region State Cycle
        public override void OnEnter()
        {
            _playerMovement.state = MovementStateEnum.Idle;
        }

        public override void OnUpdate()
        {
            _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (_input.sqrMagnitude > 0)
            {
                _playerMovement.TransitionTo(new MovementStateWalk(_playerMovement));
            }

            if (Input.GetButtonDown("Dash"))
            {
                _playerMovement.TransitionTo(new MovementStateDash(_playerMovement));
            }
        }
        #endregion


        #region Private Variables

        Vector2 _input;

        #endregion
    }
}
