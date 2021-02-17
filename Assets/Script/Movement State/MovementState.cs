using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown {
    public enum MovementStateEnum { None, Idle, Walk, Dash, Sprint };

    public abstract class MovementState 
    {
        public MovementState(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }

        public virtual void OnEnter(){}
        public virtual void OnUpdate(){}
        public virtual void OnFixedUpdate(){}
        public virtual void OnExit(){}

        protected PlayerMovement _playerMovement;
    }
}
