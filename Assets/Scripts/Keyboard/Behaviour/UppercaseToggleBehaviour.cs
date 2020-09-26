using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UppercaseToggleBehaviour : MonoBehaviour
    {
        private Image _image;
        private UppercaseToggle _keyboardObject;

        public void Init(UppercaseToggle keyboardObject)
        {
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
                    _image.sprite = Resources.Load<Sprite>(_keyboardObject.Image);
                    break;
                case ShiftMode.UppercaseSingle:
                    _image.sprite = Resources.Load<Sprite>(_keyboardObject.ImageToggledOnResourcePath);
                    break;
                case ShiftMode.UppercaseLock:
                    _image.sprite = Resources.Load<Sprite>(_keyboardObject.ImageCapsLock);
                    break;
            }
        }
    }
}