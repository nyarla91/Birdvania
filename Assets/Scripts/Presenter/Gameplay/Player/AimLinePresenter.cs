using Model.Gameplay.Player;
using UnityEngine;
using View.Gameplay.Player;

namespace Presenter.Gameplay.Player
{
    public class AimLinePresenter : MonoBehaviour
    {
        [SerializeField] private AimLineView _view;
        
        private PlayerControls _controls;
        private PlayerAim _aim;

        public void Init(PlayerAim aim, PlayerControls controls)
        {
            _aim = aim;
            _controls = controls;
            _aim.OnStartAim += _view.Show;
            _aim.OnEndAim += _view.Hide;
        }

        private void Update()
        {
            if (!_controls.AimDirection.Equals(Vector3.zero))
                _view.RotateToDirection(_controls.AimDirection);
        }
    }
}