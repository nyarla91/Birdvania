using System;
using NyarlaEssentials;
using TMPro;
using UnityEngine;

namespace View.Gameplay.Player
{
    public class AimLineView : Transformer
    {
        [SerializeField] private Transform _mesh;
        [SerializeField] private float _regularScale;
        [SerializeField] private float _thickScale;
        
        public void RotateToDirection(Vector3 direction)
        {
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }

        public void SetLength(float length)
        {
            _mesh.localPosition = new Vector3(0, 0.65f, length / 2);
            _mesh.localScale = _mesh.localScale.WithZ(length);
        }

        public void GetThick() => _mesh.localScale = new Vector3(_thickScale, _thickScale, _mesh.localScale.z);
        public void GetThin() => _mesh.localScale = new Vector3(_regularScale, _regularScale, _mesh.localScale.z);

        public void Show() => _mesh.gameObject.SetActive(true);
        public void Hide() => _mesh.gameObject.SetActive(false);

        private void Start()
        {
            _mesh.gameObject.SetActive(false);
            GetThin();
        }
    }
}