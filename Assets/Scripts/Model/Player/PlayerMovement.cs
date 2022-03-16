using System.Collections;
using Model.Entity;
using NyarlaEssentials;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Model.Player
{
    public sealed class PlayerMovement : PlayerComponent
    {
        private static readonly string[] WalksStates = {"Regular", "Aiming", "Fall"};
        
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _glideFallSpeed;
        [Header("Roll")]
        [SerializeField] private float _rollDuration;
        [SerializeField] private AnimationCurve _rollSpeedCurve;
        [SerializeField] private float _rollSpeedModifier;
        [SerializeField] private float _rollCooldown;
        
        private GameplayControls _controls;
        private Coroutine _rollCoroutine;
        private Timer _rollCooldownTimer;
        private bool _rollReady = true;
        private bool _glidingHold;

        private Movable _movable;
        public Movable Movable => _movable ??= GetComponent<Movable>();

        [Inject]
        private void Construct(GameplayControls controls)
        {
            _controls = controls;
            _controls.General.RollGlide.performed += RollPressed;
            _controls.General.RollGlide.started += StartGlide;
            _controls.General.RollGlide.canceled += EndGlide;
        }

        private void RollPressed(InputAction.CallbackContext context)
        {
            Vector3 direction = Controls.WorldMoveVector;
            if (!_rollReady || direction.magnitude == 0)
                return;
            
            if (StateMachine.TrySwitchToState("Roll"))
            {
                _rollCoroutine = StartCoroutine(Roll(direction));
            }
        }

        private IEnumerator Roll(Vector3 direction)
        {
            gameObject.layer = 11;
            _rollReady = false;
            _rollCooldownTimer.Restart();
            for (float i = 0; i < _rollDuration; i += Time.fixedDeltaTime)
            {
                float speed = _rollSpeedCurve.Evaluate(i / _rollDuration) * _rollSpeedModifier;
                Movable.Move(direction * speed * Time.fixedDeltaTime, true, false);
                yield return new WaitForFixedUpdate();
            }
            StateMachine.TrySwitchToState("Regular");
        }

        private void ExitRoll()
        {
            gameObject.layer = 6;
            StopCoroutine(_rollCoroutine);
            _rollCoroutine = null;
        }

        private void Start()
        {
            StateMachine.GetState("Roll").OnExit += ExitRoll;
            _rollCooldownTimer = new Timer(this, _rollCooldown);
            _rollCooldownTimer.OnExpired += () => _rollReady = true;
            Movable.OnFallStart += () => StateMachine.TrySwitchToState("Fall");
            Movable.OnGrounded += () =>
            {
                if (StateMachine.IsCurrentState("Fall"))
                    StateMachine.TrySwitchToState("Regular");
            };
        }

        private void Update()
        {
            Movable.MaxFallingSpeed = _glidingHold ? _glideFallSpeed : -1;
        }

        private void FixedUpdate()
        {
            Walk(Controls.WorldMoveVector);
        }

        private void Walk(Vector3 direction)
        {
            if (StateMachine.IsCurrentStateNoneOf(WalksStates) || direction.Equals(Vector3.zero))
                return;
            
            Marker.RotateToDirection(direction, _rotationSpeed * Time.fixedDeltaTime);
            Vector3 delta = direction * _speed * Time.fixedDeltaTime;
            Movable.Move(delta, true, false);
        }

        private void StartGlide(InputAction.CallbackContext context) => _glidingHold = true;
        private void EndGlide(InputAction.CallbackContext context) => _glidingHold = false;

        private void OnDestroy()
        {
            _controls.General.RollGlide.performed -= RollPressed;
            _controls.General.RollGlide.started -= StartGlide;
            _controls.General.RollGlide.started -= EndGlide;
        }
    }
}
