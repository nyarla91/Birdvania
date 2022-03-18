using NyarlaEssentials;
using UnityEngine;

namespace Model.Gameplay.UI
{
    [RequireComponent(typeof(Canvas))]
    public class MainCanvas : Transformer
    {
        public static float ScreenScale => (float) Screen.width / 1920;
        
        private Canvas _canvas;

        public Canvas Canvas => _canvas ??= GetComponent<Canvas>();
    }
}