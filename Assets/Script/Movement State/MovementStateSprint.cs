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
            _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (_input.sqrMagnitude > 0)
            {
                playerMovement.rotation = _input.normalized;
            }

            if (Input.GetButtonUp("Dash"))
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
            playerMovement.MoveTowardsDirection(_input, _speed);
        }

        #endregion


        #region Private Variables

        Vector2 _input;
        float _speed;

        #endregion
    }
}
