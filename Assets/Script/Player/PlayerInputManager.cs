using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown {
    public class PlayerInputManager : MonoBehaviour
    {

        #region Show In Inspector
        [SerializeField] private float _threshold;
        #endregion


        #region Properties
        public Vector2 Direction { get; private set; }
        public Vector2 LastDirection { get; private set; }
        public bool HasMovementInput { get; private set; }

        public bool ReleaseDash { get; private set; }

        public bool PressDash { get; private set; }

        #endregion


        #region Singleton
        private static PlayerInputManager _instance;
        public static PlayerInputManager Instance  { get => _instance; }

        private void InitSingleton()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this);
            }
        }
        #endregion


        #region Unity Cycle
        private void Awake()
        {
            InitSingleton();
            LastDirection = Vector2.up;
        }

        private void Update()
        {
            PressDash = Input.GetButtonDown("Dash");
            ReleaseDash = Input.GetButtonUp("Dash");

            Direction = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            float magnitude = Mathf.Clamp01(Direction.magnitude);
            Direction = Direction.normalized * magnitude;

            HasMovementInput = Mathf.Abs(Direction.x) >= _threshold || Mathf.Abs(Direction.y) >= _threshold;

            if(HasMovementInput)
            {
                LastDirection = Direction;
            }
    
         }
        #endregion
    }
}
