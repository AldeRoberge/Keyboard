using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public static class KeyboardSkins
    {
        public static readonly DefaultSkin DefaultSkin = new DefaultSkin();
    }

    public class DefaultSkin : KeyboardSkin
    {
        public override Color GetKeyboardBackgroundColor() => new Color(0.16f, 0.16f, 0.16f);
        public override Color GetKeyBackgroundColor() => new Color(0.52f, 0.52f, 0.52f);
        public override Color GetKeyForegroundColor() => new Color(0.89f, 0.89f, 0.89f);
        public override Sprite GetBackgroundImage() => Resources.Load<Sprite>("Keyboard/KeyBackgroundImage");

        public override Sprite GetKeyBackgroundImage() => AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");

        public override TMP_FontAsset GetTextFont() => Resources.Load<TMP_FontAsset>("Keyboard/Fonts/Gilroy-Bold");

        public override float GetBackgroundImagePixelsPerUnitMultiplier() => 7;

        public override Dictionary<string, string> GetKeyToResourcesMap()
        {
            return new Dictionary<string, string>()
            {
                {"arrow-up-empty", "Keyboard/arrow-up-empty"},
                {"arrow-up", "Keyboard/arrow-up"},
                {"arrow-up-line", "Keyboard/arrow-up-line"},
                {"backspace", "Keyboard/backspace"},
            };
        }
    }

    public abstract class KeyboardSkin
    {
        public abstract Color GetKeyboardBackgroundColor();
        public abstract Color GetKeyBackgroundColor();
        public abstract Color GetKeyForegroundColor();
        public abstract Sprite GetBackgroundImage();
        public abstract float GetBackgroundImagePixelsPerUnitMultiplier();
        public abstract Sprite GetKeyBackgroundImage();

        public abstract TMP_FontAsset GetTextFont();

        public abstract Dictionary<string, string> GetKeyToResourcesMap();

        public T Load<T>(string key) where T : Object
        {
            Dictionary<string, string> resourcesMap = GetKeyToResourcesMap();

            if (!resourcesMap.ContainsKey(key))
            {
                Debug.LogError("Missing key '" + key + "'.");
                return default;
            }

            string resourcePath = resourcesMap[key];

            T resource = Resources.Load<T>(resourcePath);

            if (resource == null)
            {
                Debug.LogError("There is no resource of type " + typeof(T) + " with path '" + resourcePath + "' in the Resource folder.");
            }

            return resource;
        }
    }
}