using UnityEngine;

namespace TopDown {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float _walkingSpeed;
        [SerializeField] private float _runningSpeed;
        [SerializeField] private float _dashSpeed;
        [SerializeField] private float _stopThreshold;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            _rigidbody.velocity = _velocity;
        }

        public void Walk()
        {
            Move(_walkingSpeed);
        }

        public void Run()
        {
            Move(_runningSpeed);
        }

        public void Dash()
        {
            _velocity = PlayerInputManager.Instance.LastDirection * _dashSpeed;
        }

        public void Stop()
        {
            _velocity = Vector2.zero;
        }

        private void Move(float speed)
        {
            _velocity = PlayerInputManager.Instance.Direction * speed * Time.fixedDeltaTime * 100;
            
        }



        public bool IsMoving()
        {
            return _rigidbody.velocity.sqrMagnitude > _stopThreshold * _stopThreshold;
        }


        private Vector2 _velocity;
        private Rigidbody2D _rigidbody;
    }
}
