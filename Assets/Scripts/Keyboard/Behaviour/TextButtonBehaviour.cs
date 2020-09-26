using DefaultNamespace.Utils;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class TextButtonBehaviour : MonoBehaviour
    {
        public TextMeshProUGUI Text;

        public void Init(TextButton textButton, Color keyColor)
        {
            InitTMP(textButton, keyColor);
        }

        private void InitTMP(TextButton textButton, Color color)
        {
            GameObject textChild = new GameObject(textButton.Name);
            textChild.transform.parent = gameObject.transform;

            Text = textChild.AddComponent<TextMeshProUGUI>();
            Text.text = textButton.Name;
            Text.color = color;
            Text.fontSize = textButton.FontSize;
            Text.horizontalAlignment = HorizontalAlignmentOptions.Center;
            Text.verticalAlignment = VerticalAlignmentOptions.Middle;

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