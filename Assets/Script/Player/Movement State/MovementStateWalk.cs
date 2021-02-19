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
            return true;
        }

        public override void OnUpdate(PlayerMovement playerMovement)
        {
            playerMovement.Controller.Walk();
            playerMovement.Animation.UpdateDirection();

            if (PlayerInputManager.Instance.PressDash)
            {
                playerMovement.TransitionTo(_dashState);
            }
        }

        public override void OnFixedUpdate(PlayerMovement playerMovement)
        {
            if (!playerMovement.Controller.IsMoving())
            {
                playerMovement.TransitionTo(_idleState);
            } 
        }
        #endregion

    }
}
