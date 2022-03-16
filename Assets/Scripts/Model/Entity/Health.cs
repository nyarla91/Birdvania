using UnityEngine;

namespace Model.Entity
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _health;

        public void TakeDamage(int damage)
        {
            _health -= damage;
        }
    }
}