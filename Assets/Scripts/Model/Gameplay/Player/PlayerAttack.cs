using System;
using Model.Controls;
using Model.Gameplay.Entity;
using NyarlaEssentials;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Model.Gameplay.Player
{
    [RequireComponent(typeof(MeleeAttack))]
    public class PlayerAttack : PlayerComponent
    {
        [SerializeField] private float _attackSeriesCooldown;
        private GameplayControls _controls;
        private MeleeAttack _meleeAttack;

        private InputBuffer _attackBuffer;
        private Timer _attackSeriesCooldownTimer;
        private bool _attackAllowed;
        private bool _attackReady = true;

        public MeleeAttack MeleeAttack => _meleeAttack ??= GetComponent<MeleeAttack>();
        
        [Inject]
        private void Construct(GameplayControls controls)
        {
            _controls = controls;
            _controls.Regular.Attack.performed += AttackPressed;
            _attackBuffer = new InputBuffer(this, 0.4f);
            _attackBuffer.OnPerformed += PerformAttack;
            _attackSeriesCooldownTimer = new Timer(this, _attackSeriesCooldown, false, true);
            _attackBuffer.OnPerformed += () => _attackReady = true;
        }

        private void AttackPressed(InputAction.CallbackContext context) => _attackBuffer.SendInput();

        private void PerformAttack()
        {
            if (Controls.InputScheme == InputScheme.KeyboardMouse)
                Marker.RotateToDirection(Controls.AimDirection, Single.MaxValue);
            
            MeleeAttack.PerformAttack(0);
            _attackReady = false;
            _attackSeriesCooldownTimer.Restart();
        }

        private void Update()
        {
            _attackAllowed = StateMachine.CurrentState.CanSwitchToState("Attack") && _attackReady;
            _attackBuffer.PerformAllowed = _attackAllowed;
        }

        private void OnDestroy()
        {
            _controls.Regular.Attack.performed -= _attackBuffer.SendInput;
        }
    }
}