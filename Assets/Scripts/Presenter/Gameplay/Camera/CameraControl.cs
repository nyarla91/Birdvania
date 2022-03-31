using System;
using Model.Gameplay.Player;
using NyarlaEssentials;
using UnityEngine;
using Zenject;

namespace Presenter.Gameplay.Camera
{
    public class CameraControl : Transformer
    {
        [SerializeField] private float _aimInfluence;
        [SerializeField] private Vector2 _speed;
        
        private Transform _player;

        [Inject]
        private void Construct(PlayerMarker player)
        {
            _player = player.transform;
        }

        private void FixedUpdate()
        {
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = _player.position;
            Vector3 XZ = Vector3.Lerp(currentPosition.WithY(0), targetPosition.WithY(0), _speed.x * Time.fixedDeltaTime);
            float Y = Mathf.Lerp(currentPosition.y, targetPosition.y, _speed.y * Time.fixedDeltaTime);
            transform.position = new Vector3(XZ.x, Y, XZ.z);
        }
    }
}