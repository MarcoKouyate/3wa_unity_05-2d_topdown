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
            _speed = playerMovement.RunningSpeed;
            return true;
        }

        public override void OnUpdate(PlayerMovement playerMovement)
        {

            if (PlayerInputManager.Instance.ReleaseDash)
            {
                if(playerMovement.Rigidbody.velocity.sqrMagnitude != 0)
                {
                    playerMovement.TransitionTo(_walkState);
                } else
                {
                    playerMovement.TransitionTo(_idleState);
                }

            }
        }

        public override void OnFixedUpdate(PlayerMovement playerMovement)
        {
            playerMovement.MoveTowardsDirection(PlayerInputManager.Instance.Direction, _speed);
        }

        #endregion


        #region Private Variables
        float _speed;

        #endregion
    }
}
