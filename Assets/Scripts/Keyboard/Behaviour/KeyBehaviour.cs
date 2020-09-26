using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class KeyBehaviour : MonoBehaviour
    {
        public bool IsUppercase;
        public TextMeshProUGUI Text;

        public void Init(TextMeshProUGUI textMeshProUgui)
        {
            Text = textMeshProUgui;
        }

        public void SetUppercase(bool isUppercase)
        {
            IsUppercase = isUppercase;
            UpdateKeyText();
        }

        private void UpdateKeyText()
        {
            if (IsUppercase)
                Text.text = Text.text.ToUpper();
            else
                Text.text = Text.text.ToLower();
        }
    }
}