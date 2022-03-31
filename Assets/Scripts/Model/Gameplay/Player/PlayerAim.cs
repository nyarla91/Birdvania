using System;
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
        private RaycastHit _hitscanReuslt;
        private bool _aimHold;

        public RaycastHit HitscanReuslt => _hitscanReuslt;

        public event Action OnStartAim;
        public event Action OnEndAim;

        [Inject]
        private void Construct(GameplayControls controls)
        {
            _controls = controls;
            _controls.General.Aim.started += AimPressed;
            _controls.General.Aim.canceled += AimReleased;
        }

        private void AimPressed(InputAction.CallbackContext context) => _aimHold = true;

        private void AimReleased(InputAction.CallbackContext context) => _aimHold = false;

        private void StartAim()
        {
            OnStartAim?.Invoke();
        }

        private void EndAim()
        {
            OnEndAim?.Invoke();
        }

        private void Start()
        {
            _line.Init(this, Gun, Controls);
            _aimState = StateMachine.GetState(AimingState);
            _aimState.OnEnter += StartAim;
            _aimState.OnExit += EndAim;
        }

        private void Update()
        {
            if (_aimHold)
                StateMachine.TryEnterState(AimingState);
            else
                StateMachine.TryExitState(AimingState);

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
            Physics.Raycast(ray, out _hitscanReuslt, 50, layerMask, QueryTriggerInteraction.Collide);
        }
    }
}