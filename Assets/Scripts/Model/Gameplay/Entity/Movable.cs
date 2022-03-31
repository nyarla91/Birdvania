using System;
using System.Collections.Generic;
using System.Linq;
using Model.Gameplay.Player;
using NyarlaEssentials;
using UnityEngine;

namespace Model.Gameplay.Entity
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movable : Transformer
    {
        [SerializeField] private bool _blockedByObstacle = true;
        [Header("Force")]
        [SerializeField] private float  _forceDrag = 10;
        [SerializeField] private bool  _canBePushedByOpponent = true;
        [SerializeField] private bool _isGrounded;

        private StateMachine _stateMachine;
        private Rigidbody _rigidbody;
        private readonly Dictionary<Transform, Vector3> _floors = new Dictionary<Transform, Vector3>();
        private Vector3 _compositeNormal = Vector3.zero;

        public event Action OnFallStart;
        public event Action OnGrounded;

        private bool BlockedByObstacle => gameObject.layer != 11 && gameObject.layer != 15;

        private bool IsGrounded
        {
            get => _isGrounded;
            set
            {
                if (value == _isGrounded)
                    return;
                _isGrounded = value;
                if (_isGrounded)
                    OnGrounded?.Invoke();
                else
                    OnFallStart?.Invoke();
            }
        }

        private Vector3 CompositeFrameMovement { get; set; }
        
        private Rigidbody Rigidbody => _rigidbody ??= GetComponent<Rigidbody>();
        private StateMachine StateMachine => _stateMachine ??= GetComponent<StateMachine>();

        public float MaxFallingSpeed { get; set; } = -1;
        public Vector3 Force { get; private set; }

        public void AddForce(Vector3 force, bool opponent)
        {
            if (!_canBePushedByOpponent && opponent)
                return;

            Force += force;
        }

        public void SetForce(Vector3 force, bool opponent)
        {
            if (!_canBePushedByOpponent && opponent)
                return;

            Force = force;
        }


        public void Move(Vector3 delta, bool alongTheSurface, bool clips)
        {
            if (alongTheSurface)
                delta = AlignVector(delta);
            
            if (!clips)
            {
                delta = CalculatePatency(delta);
            }
            CompositeFrameMovement += delta;
        }

        private Vector3 CalculatePatency(Vector3 delta)
        {
            LayerMask raycastMask = LayerMask.GetMask(BlockedByObstacle
                ? new[] {"Wall", "Obstacle"}
                : new[] {"Wall"});
            Ray ray = new Ray(transform.position, delta);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, delta.magnitude, raycastMask))
            {
                delta = raycastHit.point - transform.position - delta.normalized * 0.2f;
            }

            return delta;
        }

        private Vector3 AlignVector(Vector3 direction) =>
            direction - Vector3.Dot(direction, _compositeNormal) * _compositeNormal;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer.Equals(13))
            {
                IsGrounded = true;
                _floors.Add(other.transform, other.contacts[0].normal);
                UpdateFloorsNormalAndParent();
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (_floors.ContainsKey(other.transform))
            {
                _floors.Remove(other.transform);
                UpdateFloorsNormalAndParent();
            }
        }

        private void UpdateFloorsNormalAndParent()
        {
            _compositeNormal = _floors.Values.ToArray().LerpMulti().normalized;
            if (_floors.Count > 0)
            {
                Transform parent = _floors.Keys.OrderBy(floor => floor.gameObject.isStatic ? 1 : 0).ToList()[0];
                transform.parent = parent;
            }
            else
            {
                transform.parent = null;
            }
        }

        private void FixedUpdate()
        {
            Force = Vector3.Lerp(Force, Vector3.zero, Time.fixedDeltaTime * _forceDrag);
            if (Force.magnitude > 0.1f)
                Move(Force * Time.fixedDeltaTime, true, false);

            IsGrounded = _floors.Count > 0;
            Rigidbody.useGravity = !(StateMachine.IsCurrentState(PlayerHarpoon.HarpoonState) || IsGrounded);
            
            if (MaxFallingSpeed > 0 && Rigidbody.velocity.y < -MaxFallingSpeed)
            {
                Rigidbody.velocity = Rigidbody.velocity.WithY(-MaxFallingSpeed);
            }

            Rigidbody.position += CompositeFrameMovement;
            CompositeFrameMovement = Vector3.zero;
        }
    }
}
