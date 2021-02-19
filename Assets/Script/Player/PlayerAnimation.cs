using UnityEngine;

namespace TopDown {
    [RequireComponent (typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Update()
        {
            Set2DInput(PlayerInputManager.Instance.LastDirection);
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



        private Animator _animator;
    }
}
