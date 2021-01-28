using UnityEngine;
using System.Collections.Generic;

namespace Utils
{
    public static class TransformAddons
    {
        public static void DestroyComponent<T>(this Transform transform) where T : Component
        {
            Object.Destroy(transform.GetComponent<T>());
        }

        public static void DestroyComponentsInChildren<T>(this Transform transform) where T : Component
        {
            foreach (T component in transform.GetComponentsInChildren<T>())
                Object.Destroy(component);
        }

        public static void DestroyAllChildren(this Transform transform)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
                Object.Destroy(transform.GetChild(i).gameObject);
        }

        public static void ForEachChild(this Transform t, System.Action<Transform> Action)
        {
            for (int i = 0; i < t.childCount; i++)
                Action(t.GetChild(i));
        }

        public static List<T> GetComponentsInThisAndChildren<T>(this Transform t) where T : Component
        {
            return new List<T>(t.GetComponentsInChildren<T>())
            {
                t.GetComponent<T>()
            };
        }
    }
}
