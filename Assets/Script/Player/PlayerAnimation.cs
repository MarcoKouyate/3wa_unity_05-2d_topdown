using UnityEngine;

namespace TopDown {
    [RequireComponent (typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetHorizontalInput(float amount)
        {
            _animator.SetFloat(_horizontalId, amount);
        }


        public void SetVerticalInput(float amount)
        {
            _animator.SetFloat(_verticalId, amount);
        }

        public void Set2DInput(Vector2 input)
        {
            SetHorizontalInput(input.x);
            SetVerticalInput(input.y);
        }

        public void Roll()
        {
            _animator.SetTrigger(_rollId);
        }

        public void Run()
        {
            _animator.SetTrigger(_sprintId);
        }

        public void Walk()
        {
            _animator.SetTrigger(_walkId);
        }

        public void Idle()
        {
            _animator.SetTrigger(_idleId);
        }

        public void UpdateDirection()
        {
            Set2DInput(PlayerInputManager.Instance.LastDirection);
        }

        private int _walkId = Animator.StringToHash("Walk");
        private int _rollId = Animator.StringToHash("Roll");
        private int _idleId =  Animator.StringToHash("Idle");
        private int _sprintId = Animator.StringToHash("Sprint");
        private int _verticalId = Animator.StringToHash("Vertical");
        private int _horizontalId = Animator.StringToHash("Horizontal");
        private Animator _animator;
    }
}
