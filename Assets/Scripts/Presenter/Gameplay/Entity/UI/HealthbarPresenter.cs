
using Model.Gameplay.Entity;
using Model.Gameplay.UI;
using NyarlaEssentials;
using UnityEngine;
using View.Gameplay.Entity.UI;

namespace Presenter.Gameplay.Entity.UI
{
    public class HealthbarPresenter : Transformer
    {
        [SerializeField] private HealthbarView _view;

        private HealthStorage _targetHealthStorage;
        private UnityEngine.Camera _mainCamera;
        private Vector2 _offset;

        public void Init(HealthStorage targetHealthStorage, float width, Vector2 offset, CameraProperties cameraProperties)
        {
            _targetHealthStorage = targetHealthStorage;
            _targetHealthStorage.OnHealthChanged += RecalculateHealthbar;
            _mainCamera = cameraProperties.Main;
            _offset = offset;
            if (targetHealthStorage.ShowMode != HealthShowMode.Always)
                _view.Hide();
        }

        private void RecalculateHealthbar(int health, int healthMax)
        {
            switch (_targetHealthStorage.ShowMode)
            {
                case HealthShowMode.Always:
                {
                    _view.Show();
                    break;
                }
                case HealthShowMode.Never:
                {
                    _view.Hide();
                    break;
                }
                case HealthShowMode.WhenDamaged:
                {
                    if (health < healthMax)
                        _view.Show();
                    else
                        _view.Hide();
                    break;
                }
            }
            
            float percent = (float) health / (float) healthMax;
            _view.UpdateHealthbar(percent);
        }

        private void Update()
        {
            Vector3 _targetWorldPosition = _targetHealthStorage.transform.position;
            Vector2 _targetScreenPosition =  _mainCamera.WorldToScreenPoint(_targetWorldPosition) / MainCanvas.ScreenScale;
            _view.ScreenPosition = _targetScreenPosition + _offset;
        }
    }
}