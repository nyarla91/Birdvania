using NyarlaEssentials;
using UnityEngine;

namespace View.Gameplay.Entity.UI
{
    public class HealthbarView : Transformer
    {
        [SerializeField] private RectTransform _healthbar;
        [SerializeField] private RectTransform _foreground;

        public Vector2 ScreenPosition
        {
            get => _healthbar.anchoredPosition;
            set => _healthbar.anchoredPosition = value;
        }
        
        public void UpdateHealthbar(float percent)
        {
            percent = Mathf.Clamp(percent, 0, 1);
            _foreground.localScale = new Vector3(percent, 1, 1);
        }

        public void Show() => _healthbar.gameObject.SetActive(true);
        public void Hide() => _healthbar.gameObject.SetActive(false);
    }
}