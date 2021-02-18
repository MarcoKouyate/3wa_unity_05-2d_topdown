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
            playerMovement.state = MovementStateEnum.Dash;
            _endTime = Time.time + playerMovement.DashDuration;
            _speed = playerMovement.DashSpeed;
            _hasReleasedButton = false;

            return true;
        }


        public override void OnUpdate(PlayerMovement playerMovement)
        {
            _hasReleasedButton |= Input.GetButtonUp("Dash");

            if (Time.time > _endTime)
            {
                Transition(playerMovement);
            }
        }

        public override void OnFixedUpdate(PlayerMovement playerMovement)
        {
            playerMovement.Rigidbody.velocity = playerMovement.rotation * _speed * Time.fixedDeltaTime * 100;
        }


        public override bool OnExit(PlayerMovement playerMovement)
        {
            base.OnExit(playerMovement);
            playerMovement.Rigidbody.velocity = Vector2.zero;
            return true;
        }
        #endregion


        #region Transitions
        private void Transition(PlayerMovement playerMovement)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                if(_hasReleasedButton)
                {
                    playerMovement.TransitionTo(_walkState);
                } else
                {
                    Debug.Log("Sprint");
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
        private float _speed;
        private bool _hasReleasedButton;
        #endregion

    }
}
