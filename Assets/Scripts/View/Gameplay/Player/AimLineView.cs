using NyarlaEssentials;
using UnityEngine;

namespace View.Gameplay.Player
{
    public class AimLineView : Transformer
    {
        [SerializeField] private GameObject _mesh;
        
        public void RotateToDirection(Vector3 direction)
        {
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }

        public void Show() => _mesh.SetActive(true);
        public void Hide() => _mesh.SetActive(false);
    }
}