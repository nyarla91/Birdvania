using System;
using System.Collections.Generic;
using System.Linq;
using NyarlaEssentials;
using UnityEngine;

namespace Model.Entity
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movable : Transformer
    {
        [SerializeField] private float  _minSpeedToFall;
        [SerializeField] private bool _blockedByObstacle = true;
        [Header("Force")]
        [SerializeField] private float  _forceDrag = 10;
        [SerializeField] private bool  _canBePushedByOpponent = true;
        
        private Rigidbody _rigidbody;
        private Dictionary<GameObject, Vector3> _contacts = new Dictionary<GameObject, Vector3>();
        private Vector3 _compositeNormal = Vector3.zero;
        private bool _isGrounded;

        public event Action OnFallStart;
        public event Action OnGrounded;

        public bool BlockedByObstacle
        {
            get => _blockedByObstacle;
            set => _blockedByObstacle = value;
        }

        public bool IsGrounded
        {
            get => _isGrounded;
            private set
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
        private Rigidbody Rigidbody => _rigidbody ??= GetComponent<Rigidbody>();

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
            
            Vector3 targetPosition = transform.position + delta;
            if (clips)
            {
                targetPosition = CalculatePatency(delta, targetPosition);
            }
            Rigidbody.position = targetPosition;
        }

        private Vector3 CalculatePatency(Vector3 delta, Vector3 targetPosition)
        {
            LayerMask raycastMask = LayerMask.GetMask("Wall");
            if (BlockedByObstacle)
                raycastMask += LayerMask.GetMask("Obstacle");
            Ray ray = new Ray(transform.position, delta);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, delta.magnitude, raycastMask))
            {
                targetPosition = raycastHit.point - delta.normalized * 0.2f;
            }

            return targetPosition;
        }

        private Vector3 AlignVector(Vector3 direction) =>
            direction - Vector3.Dot(direction, _compositeNormal) * _compositeNormal;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer.Equals(13))
            {
                IsGrounded = true;
                _contacts.Add(other.gameObject, other.contacts[0].normal);
                UpdateCompositeNormal();
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (_contacts.ContainsKey(other.gameObject))
            {
                _contacts.Remove(other.gameObject);
                UpdateCompositeNormal();
            }
        }

        private void UpdateCompositeNormal()
        {
            _compositeNormal = _contacts.Values.ToArray().LerpMulti().normalized;
        }

        private void FixedUpdate()
        {
            Force = Vector3.Lerp(Force, Vector3.zero, Time.fixedDeltaTime * _forceDrag);
            if (Force.magnitude > 0.1f)
                Move(Force * Time.fixedDeltaTime, true, false);
            
            if (Rigidbody.velocity.y < -_minSpeedToFall)
                IsGrounded = false;
            if (MaxFallingSpeed > 0 && Rigidbody.velocity.y < -MaxFallingSpeed)
            {
                Rigidbody.velocity = Rigidbody.velocity.WithY(-MaxFallingSpeed);
            }
        }
    }
}
