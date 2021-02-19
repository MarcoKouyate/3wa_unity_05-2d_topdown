using UnityEngine;

namespace TopDown {
    [CreateAssetMenu(fileName= "MovementState Idle", menuName = "Custom/Player Movement State/Idle")]
    public class MovementStateIdle : MovementState
    {
        #region Show In Inspector
        [SerializeField] private MovementState _walkState;
        [SerializeField] private MovementState _dashState;
        #endregion

        #region State Cycle
        public override bool OnEnter(PlayerMovement playerMovement)
        {
            base.OnEnter(playerMovement);
            playerMovement.Animation.UpdateDirection();
            playerMovement.state = MovementStateEnum.Idle;
            return true;
        }

        public override void OnUpdate(PlayerMovement playerMovement)
        {
            if (PlayerInputManager.Instance.HasMovementInput)
            {
                playerMovement.TransitionTo(_walkState);
            }

            if (PlayerInputManager.Instance.PressDash)
            {
                playerMovement.TransitionTo(_dashState);
            }
        }
        #endregion


        #region Private Variables

        Vector2 _input;

        #endregion
    }
}
