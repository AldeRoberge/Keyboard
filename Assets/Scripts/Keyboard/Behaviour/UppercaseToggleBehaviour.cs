using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UppercaseToggleBehaviour : MonoBehaviour
    {
        private Image _image;
        private UppercaseToggle _keyboardObject;
        private KeyboardSkin _keyboardSkin;

        public void Init(UppercaseToggle keyboardObject, KeyboardSkin keyboardSkin)
        {
            _keyboardSkin = keyboardSkin;
            _keyboardObject = keyboardObject;
            _image = GetComponentInChildren<Image>();
        }

        public void UpdateImage(ShiftMode shiftMode)
        {

            Debug.Log("Image : " + _image.gameObject.name);

            Debug.Log("Updating image... Mode : " + shiftMode);

            switch (shiftMode)
            {
                case ShiftMode.None:
                    _image.sprite = _keyboardSkin.Load<Sprite>(_keyboardObject.ImageKey);
                    break;
                case ShiftMode.UppercaseSingle:
                    _image.sprite = _keyboardSkin.Load<Sprite>(_keyboardObject.ImageToggledOnKey);
                    break;
                case ShiftMode.UppercaseLock:
                    _image.sprite = _keyboardSkin.Load<Sprite>(_keyboardObject.ImageCapsLockKey);
                    break;
            }
        }
    }
}