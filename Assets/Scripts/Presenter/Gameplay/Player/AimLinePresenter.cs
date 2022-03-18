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
        private PlayerGun _gun;

        public void Init(PlayerAim aim, PlayerGun gun, PlayerControls controls)
        {
            _aim = aim;
            _controls = controls;
            _gun = gun;
            _aim.OnStartAim += _view.Show;
            _aim.OnEndAim += _view.Hide;
            _gun.OnPowerShotCharged += _view.GetThick;
            _gun.OnPowerShotStopped += _view.GetThin;
        }

        private void Update()
        {
            if (!_controls.AimDirection.Equals(Vector3.zero))
                _view.RotateToDirection(_controls.AimDirection);
            float lineLength = _aim.HitscanReuslt.distance;
            if (lineLength <= 0)
                lineLength = 50;
            _view.SetLength(lineLength);
        }
    }
}