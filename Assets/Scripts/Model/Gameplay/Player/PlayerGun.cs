using System;
using System.Collections;
using Model.Gameplay.Entity;
using Model.Gameplay.Projectiles;
using NyarlaEssentials;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Model.Gameplay.Player
{
    public class PlayerGun : PlayerComponent
    {
        [SerializeField] private GameObject _powerShotPrefab;
        [SerializeField] private int _shotDamage;
        [SerializeField] private float _shotPushForce;
        [SerializeField] private float _powerShotHoldTime;
        private GameplayControls _controls;

        private Coroutine _chargingCoroutine;
        private float _powerShotCharge;

        public event Action OnPowerShotCharged;
        public event Action OnPowerShotStopped;
        
        [Inject]
        private void Construct(GameplayControls controls)
        {
            _controls = controls;
            _controls.Aim.Shoot.performed += ShootButtonHolded;
            _controls.Aim.Shoot.canceled += ShootButtonReleased;
        }

        private void ShootButtonHolded(InputAction.CallbackContext obj)
        {
            if (StateMachine.IsCurrentState(PlayerAim.AimingState))
            {
                _chargingCoroutine = StartCoroutine(PowerShotCharge());
            }
        }

        private void ShootButtonReleased(InputAction.CallbackContext context)
        {
            _chargingCoroutine?.StopThisCoroutine(this);
            _chargingCoroutine = null;
            OnPowerShotStopped?.Invoke();

            if (!StateMachine.IsCurrentState(PlayerAim.AimingState))
                return;
            
            if (_powerShotCharge >= _powerShotHoldTime)
                PerformPowerShot();
            else
                PerformShot(Controls.AimDirection);
            _powerShotCharge = 0;
        }

        private IEnumerator PowerShotCharge()
        {
            while (true)
            {
                _powerShotCharge += Time.fixedDeltaTime;
                if (_powerShotCharge >= _powerShotHoldTime)
                    OnPowerShotCharged?.Invoke();
                
                yield return new WaitForFixedUpdate();
            }
        }

        private void PerformShot(Vector3 direction)
        {
            if (Aim.HitscanReuslt.collider == null)
                return;
            
            if (Aim.HitscanReuslt.collider.TryGetComponent(out Hitbox target))
            {
                print($"{Aim.HitscanReuslt.collider} {Aim.HitscanReuslt.distance}");
                target.TakeHit(_shotDamage, 0.2f, direction * _shotPushForce);
            }
        }

        private void PerformPowerShot()
        {
            Projectile projectile = InstantiateForComponent<Projectile>(_powerShotPrefab, transform.position);
            projectile.Init(Controls.AimDirection);
        }
    }
}