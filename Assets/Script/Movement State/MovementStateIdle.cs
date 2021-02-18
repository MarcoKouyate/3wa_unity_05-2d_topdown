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
            playerMovement.state = MovementStateEnum.Idle;
            return true;
        }

        public override void OnUpdate(PlayerMovement playerMovement)
        {
            _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (_input.sqrMagnitude > 0)
            {
                playerMovement.TransitionTo(_walkState);
            }

            if (Input.GetButtonDown("Dash"))
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
