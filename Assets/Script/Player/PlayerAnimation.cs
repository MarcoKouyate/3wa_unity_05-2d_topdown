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
            _animator.SetFloat("Horizontal", amount);
        }


        public void SetVerticalInput(float amount)
        {
            _animator.SetFloat("Vertical", amount);
        }

        public void Set2DInput(Vector2 input)
        {
            SetHorizontalInput(input.x);
            SetVerticalInput(input.y);
        }

        public void Roll()
        {
            _animator.SetTrigger("Roll");
        }

        public void UpdateDirection()
        {
            Set2DInput(PlayerInputManager.Instance.LastDirection);
        }


        private Animator _animator;
    }
}
