using UnityEngine;

namespace Tools
{
    internal static class ResourceLoader
    {
        public static T Load<T>(ResourcePath resourcePath) where T : Object
        {
            var obj = Resources.Load<T>(resourcePath.Path);
            _ = obj ?? throw new System.Exception($"Объект {resourcePath.Path} не может быть загружен");
            return obj;
        }
    }
}
