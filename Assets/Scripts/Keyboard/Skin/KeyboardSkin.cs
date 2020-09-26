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
        public override Sprite GetBackgroundImage() => Resources.Load<Sprite>("KeyBackgroundImage");
        
        public override Sprite GetKeyBackgroundImage() => AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
        
        public override float GetBackgroundImagePixelsPerUnitMultiplier() => 7;
    }

    public abstract class KeyboardSkin
    {
        public abstract Color GetKeyboardBackgroundColor();
        public abstract Color GetKeyBackgroundColor();
        public abstract Color GetKeyForegroundColor();
        public abstract Sprite GetBackgroundImage();
        public abstract float GetBackgroundImagePixelsPerUnitMultiplier();
        
        
        public abstract Sprite GetKeyBackgroundImage();
        
        
    }
}