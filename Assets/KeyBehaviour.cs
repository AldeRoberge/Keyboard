using DefaultNamespace.Utils;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class KeyBehaviour : MonoBehaviour
    {
        private TextMeshProUGUI text;

        public void Init(Key key, Color keyColor)
        {
            InitTMP(key, keyColor);
        }

        private void InitTMP(Key key, Color color)
        {
            GameObject textChild = new GameObject(key.Name);
            textChild.transform.parent = this.gameObject.transform;

            text = textChild.AddComponent<TextMeshProUGUI>();
            text.text = key.Name;
            text.color = color;

            RectTransform rectTransform = text.GetComponent<RectTransform>();
            rectTransform.SetCentered();
        }
    }
}