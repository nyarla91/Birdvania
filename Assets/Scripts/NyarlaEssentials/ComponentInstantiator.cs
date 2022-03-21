using System;
using UnityEngine;

namespace NyarlaEssentials
{
    public class ComponentInstantiator : Transformer
    {
        protected T InstantiateForComponent<T>(GameObject prefab)
            where T : MonoBehaviour => InstantiateForComponent<T>(prefab, Vector3.zero);
        
        protected T InstantiateForComponent<T>(GameObject prefab, Vector3 position)
            where T : MonoBehaviour => InstantiateForComponent<T>(prefab, position, null);
        
        protected T InstantiateForComponent<T>(GameObject prefab, Vector3 position, Transform parent)
            where T : MonoBehaviour => InstantiateForComponent<T>(prefab, position, Quaternion.identity, parent);
        protected T InstantiateForComponent<T>(GameObject prefab, Transform parent)
            where T : MonoBehaviour => InstantiateForComponent<T>(prefab, parent.position, Quaternion.identity, parent);
        
        protected T InstantiateForComponent<T>(GameObject prefab, Vector3 position, Quaternion rotation)
            where T : MonoBehaviour => InstantiateForComponent<T>(prefab, position, rotation, null);
        
        protected T InstantiateForComponent<T>(GameObject prefab, Vector3 position, Quaternion rotation,
            Transform parent) where T : MonoBehaviour
        {
            if (prefab.GetComponent<T>() == null)
                throw new NullReferenceException($"{prefab.name} has no component of {typeof(T)} type");
            return Instantiate(prefab, position, rotation, parent).GetComponent<T>();
        }
    }
}