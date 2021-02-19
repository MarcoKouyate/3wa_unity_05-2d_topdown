using UnityEngine;

namespace TopDown {

    [CreateAssetMenu(fileName = "MovementState Dash", menuName ="Custom/Player Movement State/Dash")]
    public class MovementStateDash : MovementState
    {

        #region Show In Inspector
        [SerializeField] private MovementState _idleState;
        [SerializeField] private MovementState _walkState;
        [SerializeField] private MovementState _sprintState;
        #endregion


        #region State Cycle
        public override bool OnEnter(PlayerMovement playerMovement)
        {
            base.OnEnter(playerMovement);
            playerMovement.state = MovementStateEnum.Dash;
            playerMovement.Animation.Roll();
            playerMovement.Animation.UpdateDirection();
            playerMovement.Controller.Dash();
            _endTime = Time.time + playerMovement.DashDuration;
            _hasReleasedButton = false;
            return true;
        }


        public override void OnUpdate(PlayerMovement playerMovement)
        {
            _hasReleasedButton |= PlayerInputManager.Instance.ReleaseDash;

            if (Time.time > _endTime)
            {
                Transition(playerMovement);
            }
        }


        public override bool OnExit(PlayerMovement playerMovement)
        {
            base.OnExit(playerMovement);
            playerMovement.Controller.Stop();
            return true;
        }
        #endregion


        #region Transitions
        private void Transition(PlayerMovement playerMovement)
        {
            if (PlayerInputManager.Instance.HasMovementInput)
            {
                if(_hasReleasedButton)
                {
                    playerMovement.TransitionTo(_walkState);
                } else
                {
                    playerMovement.TransitionTo(_sprintState);
                }
            } else
            {
                playerMovement.TransitionTo(_idleState);
            }
        }
        #endregion


        #region Private Variables
        private float _endTime;
        private bool _hasReleasedButton;
        #endregion

    }
}
