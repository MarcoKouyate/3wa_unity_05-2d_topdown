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
            if (PlayerInputManager.Instance.PressDash)
            {
                playerMovement.TransitionTo(_dashState);
            }
        }

        public override void OnFixedUpdate(PlayerMovement playerMovement)
        {
            playerMovement.MoveTowardsDirection(PlayerInputManager.Instance.Direction, _speed);

            if (playerMovement.Rigidbody.velocity.sqrMagnitude == 0)
            {
                playerMovement.TransitionTo(_idleState);
            } 
        }

        #endregion

        #region Private Variables

        float _speed;

        #endregion
    }
}
