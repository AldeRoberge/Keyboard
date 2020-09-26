using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    internal class ToggleableTextButtonBehaviour : MonoBehaviour
    {
        private ToggleableTextButton toggle;
        private TextMeshProUGUI _text;

        public void Init(ToggleableTextButton toggle)
        {
            this.toggle = toggle;
            _text = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void UpdateText(bool isToggledOn)
        {
            if (isToggledOn)
                _text.text = toggle.DisplayTextToggledOn;
            else
                _text.text = toggle.Name;
        }
    }
}