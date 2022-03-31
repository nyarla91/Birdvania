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
    public class PlayerHarpoon : PlayerComponent
    {
        public const string HarpoonState = "Harpoon";

        [SerializeField] private GameObject _harpoonPrefab;
        [SerializeField] private float _pullSpeed;
        [SerializeField][Range(0, 1)] private float _minDelta;
        [SerializeField] private float _pullStopDistance;

        private Movable _movable;
        private GameplayControls _controls;
        private Coroutine _shootCoroutine;
        private Coroutine _pullCoroutine;

        private Projectile _harpoonProjectile;
        private Hitbox _pulledHitbox;

        private Movable Movable => _movable ??= GetComponent<Movable>();

        [Inject]
        private void Construct(GameplayControls controls)
        {
            _controls = controls;
            _controls.Aim.Harpoon.started += HarpoonButtonPressed;
            _controls.General.CancelHarpoon.started += CancelHatpoonButtonPressed;
        }

        private void HarpoonButtonPressed(InputAction.CallbackContext context)
        {
            if (StateMachine.TryEnterState(HarpoonState))
            {
                _shootCoroutine = StartCoroutine(Shoot());
            }
        }

        private void CancelHatpoonButtonPressed(InputAction.CallbackContext context)
        {
            if (StateMachine.IsCurrentState(HarpoonState))
            {
                EndShoot();
            }
        }

        private void EndShoot()
        {
            if (!_harpoonProjectile.Equals(null))
                _harpoonProjectile.gameObject.SelfDestruct();
            _harpoonProjectile = null;

            _pulledHitbox?.StateMachine?.TryExitState(HarpoonState);
            _pulledHitbox = null;
            
            _shootCoroutine?.Stop(this, ref _shootCoroutine);
            _pullCoroutine?.Stop(this, ref _pullCoroutine);
            
            StateMachine.TryExitState(HarpoonState);
        }

        private IEnumerator Shoot()
        {
            StateMachine.TryEnterState(HarpoonState);
            
            _harpoonProjectile = InstantiateForComponent<Projectile>(_harpoonPrefab, transform.position);
            _harpoonProjectile.Init(Controls.AimDirection);
            bool hit = false;
            
            _harpoonProjectile.OnHit += hibox =>
            {
                hit = true;
                _pulledHitbox = hibox;
            };
            _harpoonProjectile.OnMiss += () => hit = true;
            
            yield return new WaitUntil(() => hit);

            if (_pulledHitbox == null)
            {
                EndShoot();
                yield break;
            }
            
            _pulledHitbox.StateMachine?.TryEnterState(HarpoonState);
            Movable targetMovable = _pulledHitbox.Movable;
            switch (_pulledHitbox.HarpoonPullMode)
            {
                case HarpoonPullMode.PullPlayer:
                    yield return
                        _pullCoroutine = StartCoroutine(PullTargetToDestination(Movable, _pulledHitbox.transform));
                    break;
                case HarpoonPullMode.PullTarget:
                    yield return
                        _pullCoroutine = StartCoroutine(PullTargetToDestination(targetMovable, transform));
                    break;
                case HarpoonPullMode.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            EndShoot();
        }

        private IEnumerator PullTargetToDestination(Movable target, Transform destination)
        {
            while (Vector3.Distance(target.transform.position, destination.position) > _pullStopDistance)
            {
                Vector3 direction = (destination.position - target.transform.position).WithY(0.01f).normalized;
                Vector3 velocity = direction * _pullSpeed * Time.fixedDeltaTime;
                target.Move(velocity, false, false);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}