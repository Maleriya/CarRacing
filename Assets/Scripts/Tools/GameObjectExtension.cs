using UnityEngine;

namespace Tools.Extension
{
    public static class GameObjectExtension
    {
        public static void Destroy(this GameObject gameObject)
        {
            Object.Destroy(gameObject);
        }
    }
}
