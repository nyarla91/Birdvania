using System;
using Model.Controls;
using Model.Gameplay.Entity;
using Presenter.Gameplay.Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Model.Gameplay.Player
{
    public class PlayerAim : PlayerComponent
    {
        public const string AimingState = "Aiming";
        
        [SerializeField] private AimLinePresenter _line;
        
        private GameplayControls _controls;

        private Coroutine _aimingCoroutine;
        private State _aimState;
        private InputBuffer _aimBuffer;
        private RaycastHit _hitscanReuslt;

        public RaycastHit HitscanReuslt => _hitscanReuslt;

        public event Action OnStartAim;
        public event Action OnEndAim;

        [Inject]
        private void Construct(GameplayControls controls)
        {
            _controls = controls;
            _aimBuffer = new InputBuffer(this, 1);
            _controls.General.Aim.started += AimPressed;
            _controls.General.Aim.canceled += AimReleased;
        }

        private void AimPressed(InputAction.CallbackContext context)
        {
            _aimBuffer.SendInput();
        }

        private void AimReleased(InputAction.CallbackContext context)
        {
            _aimBuffer.InterruptBuffering();
            if (StateMachine.IsCurrentState(AimingState))
            {
                StateMachine.TrySwitchToState(StateMachine.Regular);
            }
        }

        private void StartAim()
        {
            if (StateMachine.TrySwitchToState(AimingState))
            {
                OnStartAim?.Invoke();
                _controls.Regular.Disable();
                _controls.Aim.Enable();
            }
        }

        private void EndAim()
        {
            OnEndAim?.Invoke();
            _controls.Aim.Disable();
            _controls.Regular.Enable();
        }

        private void Start()
        {
            _line.Init(this, Gun, Controls);
            _aimState = StateMachine.GetState(AimingState);
            _aimBuffer.OnPerformed += StartAim;
            _aimState.OnExit += EndAim;
        }

        private void Update()
        {
            if (_aimBuffer != null)
                _aimBuffer.PerformAllowed = StateMachine.CurrentState.CanSwitchToState(AimingState);

            if (StateMachine.IsCurrentState(AimingState))
            {
                Marker.RotateToDirection(Controls.AimDirection, Single.MaxValue);
                Hitscan();
            }
        }

        private void Hitscan()
        {
            LayerMask layerMask = LayerMask.GetMask(new[] {"Enemy", "Destructable", "Wall", "Floor"});
            Ray ray = new Ray(transform.position + new Vector3(0, 0.5f, 0), Controls.AimDirection);

            if (!Physics.Raycast(ray, out _hitscanReuslt, 50, layerMask, QueryTriggerInteraction.Collide))
                return;
        }
    }
}