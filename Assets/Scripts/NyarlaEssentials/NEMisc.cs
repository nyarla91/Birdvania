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

        public static void Stop(this Coroutine coroutine, MonoBehaviour container, ref Coroutine fieldToClear)
        {
            coroutine.Stop(container);
            fieldToClear = null;
        }

        public static void Stop(this Coroutine coroutine, MonoBehaviour container)
        {
            container.StopCoroutine(coroutine);
        }

        public static void SetAlpha(this Image image, float alpha)
        {
            Color originColor = image.color;
            image.color = new Color(originColor.r, originColor.g, originColor.b, alpha);
        }

        public static bool NullOrAssign<T>(this T obj, out T target)
        {
            target = obj;
            return target != null;
        }

        public static Vector3 DirectionTo(this Transform transform, Vector3 target) => target - transform.position;
        public static Vector3 DirectionTo(this Transform transform, Transform target) => target.DirectionTo(target.position);
    }
}