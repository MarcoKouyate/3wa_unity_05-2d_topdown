using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown {
    [CreateAssetMenu(fileName = "MovementState Walk", menuName = "Custom/Player Movement State/Walk")]
    public class MovementStateWalk : MovementState
    {
        #region Show in Inspector
        [SerializeField] private MovementState _dashState;
        [SerializeField] private MovementState _idleState;
        #endregion


        #region State Cycle

        public override bool OnEnter(PlayerMovement playerMovement) {
            base.OnEnter(playerMovement);
            playerMovement.state = MovementStateEnum.Walk;
            _speed = playerMovement.WalkingSpeed;
            return true;
        }
        public override void OnUpdate(PlayerMovement playerMovement)
        {
            _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            
            if(_input.sqrMagnitude > 0.1f)
            {
                playerMovement.rotation = _input.normalized;
            }

            if (Input.GetButtonDown("Dash"))
            {
                playerMovement.TransitionTo(_dashState);
            }
        }

        public override void OnFixedUpdate(PlayerMovement playerMovement)
        {
            playerMovement.MoveTowardsDirection(_input, _speed);

            if (playerMovement.Rigidbody.velocity.sqrMagnitude == 0)
            {
                playerMovement.TransitionTo(_idleState);
            } 
        }

        #endregion

        #region Private Variables

        Vector2 _input;
        float _speed;

        #endregion
    }
}
