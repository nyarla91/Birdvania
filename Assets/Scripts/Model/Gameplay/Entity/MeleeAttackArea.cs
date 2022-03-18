using System.Collections.Generic;
using UnityEngine;

namespace Model.Gameplay.Entity
{
    public class MeleeAttackArea : MonoBehaviour
    {
        [SerializeField] private List<TargetType> _allowedTargets = new List<TargetType>();
        private List<Hitbox> _targets = new List<Hitbox>();

        public List<Hitbox> Targets => _targets;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Hitbox target) && _allowedTargets.Contains(target.Type))
            {
                _targets.Add(target);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Hitbox target) && _targets.Contains(target))
            {
                _targets.Remove(target);
            }
        }
    }
}