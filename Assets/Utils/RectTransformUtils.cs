using UnityEngine;

namespace DefaultNamespace.Utils
{
    public static class RectTransformUtils
    {
        public static void SetCentered(this RectTransform rectTransform)
        {
            rectTransform.localPosition = new Vector3(0, 0, 0);
            rectTransform.localScale = new Vector3(1, 1, 1);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(1, 1);
            rectTransform.anchoredPosition = new Vector2(0, 0);
            rectTransform.sizeDelta = new Vector2(0, 0);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
        }
    }
}