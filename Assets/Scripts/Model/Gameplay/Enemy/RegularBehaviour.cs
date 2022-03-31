using System;
using UnityEngine;

namespace Model.Gameplay.Enemy
{
    public class RegularBehaviour : EnemyBehaviour
    {
        private void Start()
        {
            Movement.Target = Player.transform;
        }
    }
}