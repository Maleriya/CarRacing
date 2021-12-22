using UnityEngine;

namespace Tools.Extension
{
    public static class Extension
    {
        public static void Destroy(this GameObject gameObject)
        {
            Object.Destroy(gameObject);
        }
    }
}
