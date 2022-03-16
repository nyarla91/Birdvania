using System.Collections.Generic;
using UnityEngine;

namespace Model.Entity
{
    public class AttackHitbox : MonoBehaviour
    {
        [SerializeField] private List<AttackTarget.TargetType> _allowedTargets = new List<AttackTarget.TargetType>();
        private List<AttackTarget> _targets = new List<AttackTarget>();

        public List<AttackTarget> Targets => _targets;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out AttackTarget target) && _allowedTargets.Contains(target.Type))
            {
                _targets.Add(target);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out AttackTarget target) && _targets.Contains(target))
            {
                _targets.Remove(target);
            }
        }
    }
}