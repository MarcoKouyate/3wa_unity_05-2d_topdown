using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown {
    public class MovementStateWalk : MovementState
    {
        #region Constructor
        public MovementStateWalk(PlayerMovement playerMovement) : base(playerMovement){}
        #endregion

        #region State Cycle

        public override void OnEnter() {
            _playerMovement.state = MovementStateEnum.Walk;
        }
        public override void OnUpdate()
        {
            _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetButtonDown("Dash"))
            {
                _playerMovement.TransitionTo(new MovementStateSprint(_playerMovement));
            }
        }

        public override void OnFixedUpdate()
        {
            Vector2 velocity = _input * _playerMovement.WalkingSpeed * Time.fixedDeltaTime * 100;
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
