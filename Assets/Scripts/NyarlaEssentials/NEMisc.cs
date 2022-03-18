using UnityEngine;
using UnityEngine.UI;

namespace NyarlaEssentials
{
    public static class NEMisc
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T swapper = a;
            a = b;
            b = swapper;
        }

        public static void SelfDestruct(this GameObject gameObject)
        {
            GameObject.Destroy(gameObject);
        }

        public static void StopThisCoroutine(this Coroutine coroutine, MonoBehaviour container)
        {
            container.StopCoroutine(coroutine);
            coroutine = null;
        }

        public static void SetAlpha(this Image image, float alpha)
        {
            Color originColor = image.color;
            image.color = new Color(originColor.r, originColor.g, originColor.b, alpha);
        }
    }
}