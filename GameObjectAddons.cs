using UnityEngine;
using System;

namespace Utils
{
    public static class GameObjectAddons
    {
        public static void SetMaterialColor(this GameObject go, Color color)
        {
            foreach (Material material in go.GetComponent<Renderer>().materials)
                material.color = color;
        }

        public static void SetOnDestroy(this GameObject go, Action OnDestroy)
        {
            go.AddComponent<DestroyAction>().OnDestruction = OnDestroy;
        }

        public static void SetOnUpdate(this GameObject go, Action OnUpdate)
        {
            go.AddComponent<UpdateAction>().OnUpdate = OnUpdate;
        }

        public static void Dissolve(this GameObject go, float t)
        {
        }

        public static void Disappear(this GameObject go, float t)
        {
        }
    }
}