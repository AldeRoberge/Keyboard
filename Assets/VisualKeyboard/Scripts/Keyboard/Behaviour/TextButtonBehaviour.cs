using DefaultNamespace.Utils;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class TextButtonBehaviour : MonoBehaviour
    {
        public TextMeshProUGUI Text;

        public KeyboardSkin skin;

        public void Init(TextButton textButton, KeyboardSkin skin)
        {
            this.skin = skin;
            InitTMP(textButton, skin);
        }

        private void InitTMP(TextButton textButton, KeyboardSkin skin)
        {
            GameObject textChild = new GameObject(textButton.Name);
            textChild.transform.parent = gameObject.transform;

            Text = textChild.AddComponent<TextMeshProUGUI>();
            Text.text = textButton.Name;
            Text.color = skin.GetKeyForegroundColor();
            Text.fontSize = textButton.FontSize;
            Text.horizontalAlignment = HorizontalAlignmentOptions.Center;
            Text.verticalAlignment = VerticalAlignmentOptions.Middle;
            Text.font = skin.GetTextFont();

            RectTransform rectTransform = Text.GetComponent<RectTransform>();
            rectTransform.SetCentered();
        }

        public void SlightlyDarker()
        {
            Text.color = new Color(
                Text.color.r,
                Text.color.g,
                Text.color.b,
                0.8f);
        }
    }
}