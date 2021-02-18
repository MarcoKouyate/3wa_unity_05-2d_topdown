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
            _speed = _playerMovement.WalkingSpeed;
        }
        public override void OnUpdate()
        {
            _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            
            if(_input.sqrMagnitude > 0.1f)
            {
                _playerMovement.rotation = _input.normalized;
            }

            if (Input.GetButtonDown("Dash"))
            {
                _playerMovement.TransitionTo(new MovementStateDash(_playerMovement));
            }
        }

        public override void OnFixedUpdate()
        {
            _playerMovement.MoveTowardsDirection(_input, _speed);

            if (_playerMovement.Rigidbody.velocity.sqrMagnitude == 0)
            {
                _playerMovement.TransitionTo(new MovementStateIdle(_playerMovement));
            } 
        }

        public override void OnExit() { }

        #endregion

        #region Private Variables

        Vector2 _input;
        float _speed;

        #endregion
    }
}
