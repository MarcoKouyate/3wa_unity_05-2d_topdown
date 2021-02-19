using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown {
    [CreateAssetMenu(fileName = "MovementState Sprint", menuName = "Custom/Player Movement State/Sprint")]
    public class MovementStateSprint : MovementState
    {

        #region Show In Inspector
        [SerializeField] private MovementState _walkState;
        [SerializeField] private MovementState _idleState;
        #endregion


        #region State Cycle

        public override bool OnEnter(PlayerMovement playerMovement)
        {
            base.OnEnter(playerMovement);
            playerMovement.state = MovementStateEnum.Sprint;
            playerMovement.Animation.Run();
            return true;
        }

        public override void OnUpdate(PlayerMovement playerMovement)
        {

            playerMovement.Controller.Run();
            playerMovement.Animation.UpdateDirection();

            if (PlayerInputManager.Instance.ReleaseDash)
            {
                if(playerMovement.Controller.IsMoving())
                {
                    playerMovement.TransitionTo(_walkState);
                } else
                {
                    playerMovement.TransitionTo(_idleState);
                }

            }
        }
        #endregion
    }
}
