using UnityEngine;

namespace TopDown {
    public enum MovementStateEnum { None, Idle, Walk, Dash, Sprint };
    public enum ExecutionStateEnum { None, Active, Completed, Terminated };

    public abstract class MovementState : ScriptableObject
    {

        #region Show in Inspector
        public ExecutionStateEnum executionState;
        #endregion

        #region State Cycle

        public virtual void OnEnable()
        {
            executionState = ExecutionStateEnum.None;
        }

        public virtual bool OnEnter(PlayerMovement playerMovement) {
            executionState = ExecutionStateEnum.Active;
            return true; 
        }

        public virtual void OnUpdate(PlayerMovement playerMovement) {}

        public virtual void OnFixedUpdate(PlayerMovement playerMovement) {}

        public virtual bool OnExit(PlayerMovement playerMovement) {
            executionState = ExecutionStateEnum.Completed;
            return true; 
        }

        #endregion
    }
}
