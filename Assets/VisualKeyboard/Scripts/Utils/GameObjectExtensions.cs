using UnityEngine;

namespace DefaultNamespace.Utils
{
    public static class GameObjectExtensions
    {
        
        /// <summary>
        /// Gets or creates a Component of type T on the given GameObject.
        /// </summary>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T existingComponent = gameObject.GetComponent<T>();

            if (existingComponent != null)
            {
                return existingComponent;
            }

            return gameObject.AddComponent<T>();
        }
    }
}