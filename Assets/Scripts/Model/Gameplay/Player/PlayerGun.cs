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
        private float _shotCharge;
        
        [Inject]
        private void Construct(GameplayControls controls)
        {
            _controls = controls;
            _controls.Aim.Shoot.performed += ShootHolded;
            _controls.Aim.Shoot.canceled += ShootReleased;
        }

        private void ShootHolded(InputAction.CallbackContext obj)
        {
            if (StateMachine.IsCurrentState(PlayerAim.AimingState))
            {
                _chargingCoroutine = StartCoroutine(ShotCharge());
            }
        }

        private void ShootReleased(InputAction.CallbackContext context)
        {
            _chargingCoroutine?.StopThisCoroutine(this);
            _chargingCoroutine = null;

            if (!StateMachine.IsCurrentState(PlayerAim.AimingState))
                return;
            
            if (_shotCharge >= _powerShotHoldTime)
                PowerShot();
            else
                Shoot(Controls.AimDirection);
            _shotCharge = 0;
        }

        private IEnumerator ShotCharge()
        {
            while (true)
            {
                _shotCharge += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
        }

        private void Shoot(Vector3 direction)
        {
            LayerMask layerMask = LayerMask.GetMask(new []{"Enemy", "Destructable", "Wall", "Floor"});
            Ray ray = new Ray(transform.position + new Vector3(0, 0.5f, 0), direction);
            
            if (!Physics.Raycast(ray, out RaycastHit raycastHit, 50, layerMask, QueryTriggerInteraction.Collide))
                return;
            
            if (raycastHit.collider.TryGetComponent(out Hitbox target))
            {
                print($"{raycastHit.collider} {raycastHit.distance}");
                target.TakeHit(_shotDamage, 0.2f, direction * _shotPushForce);
            }
        }

        private void PowerShot()
        {
            Projectile projectile = InstantiateForComponent<Projectile>(_powerShotPrefab, transform.position);
            projectile.Init(Controls.AimDirection);
        }
    }
}