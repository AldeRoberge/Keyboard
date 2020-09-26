using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class KeyboardSkins
    {
        public static readonly KeyboardSkin defaultSkin = new KeyboardSkin(
            new Color(0.11f, 0.11f, 0.12f),
            new Color(0.6f, 0.6f, 0.6f),
            new Color(0.89f, 0.89f, 0.89f)
        );
    }

    public class KeyboardSkin
    {
        public Color KeyboardBackground;
        public Color KeyBackground;
        public Color KeyForeground;

        public KeyboardSkin(Color keyboardBackground, Color keyBackground, Color keyForeground)
        {
            KeyboardBackground = keyboardBackground;
            KeyBackground = keyBackground;
            KeyForeground = keyForeground;
        }

        public Sprite GetKeyBackground()
        {
            return AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
        }

        public Sprite GetBackgroundImage()
        {
            return Resources.Load<Sprite>("KeyBackgroundImage");
        }

        public float GetBackgroundImagePixelsPerUnitMultiplier()
        {
            return 7;
        }
    }
}