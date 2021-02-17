using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown {
    public class MovementStateSprint : MovementState
    {
        #region Constructor
        public MovementStateSprint(PlayerMovement playerMovement) : base(playerMovement) { }
        #endregion

        #region State Cycle

        public override void OnEnter()
        {
            _playerMovement.state = MovementStateEnum.Sprint;
        }
        public override void OnUpdate()
        {
            _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetButtonUp("Dash"))
            {
                _playerMovement.TransitionTo(new MovementStateWalk(_playerMovement));
            }
        }

        public override void OnFixedUpdate()
        {
            Vector2 velocity = _input * _playerMovement.RunningSpeed * Time.fixedDeltaTime * 100;
            _playerMovement.Rigidbody.velocity = velocity;

            if (velocity.sqrMagnitude == 0)
            {
                _playerMovement.TransitionTo(new MovementStateIdle(_playerMovement));
            }
        }

        public override void OnExit() { }

        #endregion

        #region Private Variables

        Vector2 _input;

        #endregion
    }
}
