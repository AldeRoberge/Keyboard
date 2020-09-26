using UnityEngine;

namespace DefaultNamespace
{
    public class KeyboardSkins
    {
        public static readonly KeyboardSkin defaultSkin = new KeyboardSkin(
            new Color(0.11f, 0.11f, 0.12f),
            new Color(0.22f, 0.22f, 0.22f),
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
    }
}