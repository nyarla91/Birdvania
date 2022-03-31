using System;
using NyarlaEssentials;
using Presenter.Gameplay.Camera;
using UnityEngine;
using Zenject;

namespace Model.Gameplay.Player
{
    public class PlayerMarker : PlayerComponent
    {
        public void RotateToDirection(Vector3 direction) => RotateToDirection(direction, Single.MaxValue);

        public void RotateToDirection(Vector3 direction, float maxDelta)
        {
            Vector3 targetDirection =
                Vector3.RotateTowards(transform.forward, direction, maxDelta * Mathf.Deg2Rad, 999);
            transform.rotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        }

        private void Update()
        {
            gameObject.layer = StateMachine.IsCurrentStateOneOf(
                new[] {PlayerMovement.RollState, PlayerHarpoon.HarpoonState}) ? 11 : 6;
        }
    }
}