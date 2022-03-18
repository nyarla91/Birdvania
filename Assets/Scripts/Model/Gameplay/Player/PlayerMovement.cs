using System.Collections;
using Model.Controls;
using Model.Gameplay.Entity;
using NyarlaEssentials;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Model.Gameplay.Player
{
    public sealed class PlayerMovement : PlayerComponent
    {
        public const string RollState = "Roll";
        public const string FallState= "Fall";
        private static readonly string[] WalksStates =
        {
            StateMachine.Regular, PlayerAim.AimingState, FallState
        };
        
        [SerializeField] private float _speed;
        [SerializeField] [Range(0, 1)] private float _aimSpeedModifier;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _glideFallSpeed;
        [Header("Roll")]
        [SerializeField] private float _rollDuration;
        [SerializeField] private AnimationCurve _rollSpeedCurve;
        [SerializeField] private float _rollSpeedModifier;
        [SerializeField] private float _rollCooldown;
        
        private GameplayControls _controls;
        private InputBuffer _rollBuffer;
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
            _rollBuffer = new InputBuffer(this, 0.3f);
            _rollBuffer.OnPerformed += StartRoll;
            _controls.General.RollGlide.performed += RollPressed;
            _controls.General.RollGlide.started += StartGlide;
            _controls.General.RollGlide.canceled += EndGlide;
        }

        private void RollPressed(InputAction.CallbackContext context)
        {
            _rollBuffer.SendInput();
        }

        private void StartRoll()
        {
            if (!StateMachine.TrySwitchToState(RollState))
                return;
            
            Vector3 direction = Controls.InputScheme == InputScheme.KeyboardMouse
                ? Controls.AimDirection
                : Controls.WorldMoveVector;
            if (direction.Equals(Vector3.zero))
                direction = transform.forward;
                
            Marker.RotateToDirection(direction);
            _rollCoroutine = StartCoroutine(Roll(direction));
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
            StateMachine.TrySwitchToState(StateMachine.Regular);
        }

        private void ExitRoll()
        {
            gameObject.layer = 6;
            StopCoroutine(_rollCoroutine);
            _rollCoroutine = null;
        }

        private void Start()
        {
            StateMachine.GetState(RollState).OnExit += ExitRoll;
            _rollCooldownTimer = new Timer(this, _rollCooldown);
            _rollCooldownTimer.OnExpired += () => _rollReady = true;
            Movable.OnFallStart += () => StateMachine.TrySwitchToState(FallState);
            Movable.OnGrounded += () =>
            {
                if (StateMachine.IsCurrentState(FallState))
                    StateMachine.TrySwitchToState(StateMachine.Regular);
            };
        }

        private void Update()
        {
            Movable.MaxFallingSpeed = _glidingHold ? _glideFallSpeed : -1;
            _rollBuffer.PerformAllowed = StateMachine.CurrentState.CanSwitchToState(RollState) && _rollReady;
        }

        private void FixedUpdate()
        {
            Walk(Controls.WorldMoveVector);
        }

        private void Walk(Vector3 direction)
        {
            if (StateMachine.IsCurrentStateNoneOf(WalksStates) || direction.Equals(Vector3.zero))
                return;
            
            Vector3 velocity = direction * _speed * Time.fixedDeltaTime;
            Movable.Move(velocity, true, false);
            if (StateMachine.IsCurrentState(StateMachine.Regular))
                Marker.RotateToDirection(direction, _rotationSpeed * Time.fixedDeltaTime);
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
