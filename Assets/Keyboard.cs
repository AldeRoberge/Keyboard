using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Utils;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public enum ShiftMode
{
    None,
    UppercaseSingle,
    UppercaseLock // Caps lock
}

public class Keyboard : MonoBehaviour
{
    public GameObject MainPanel;
    public List<KeyBehaviour> Keys;

    public Image ShiftToggleImage;

    public ShiftMode ShiftMode;
    public bool IsShowingSymbols;

    public TMP_InputField target;

    public KeyboardSkin KeyboardSkin = KeyboardSkins.defaultSkin;

    public UppercaseToggleBehaviour UppercaseBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure there is a valid target (input field) for the keyboard
        if (target == null)
        {
            Debug.LogError("[Keyboard] There is no target attached to this game object.\n" +
                           "Attach an object of type TMP_InputField on this script.");
            Destroy(this);
        }

        ShiftMode = ShiftMode.None;

        InitCanvas();
        CreateMainPanel(KeyboardSkin);
        PopulatePanels(KeyboardSkin, Layout.Normal);
    }

    private void ToggleUppercase()
    {
        switch (ShiftMode)
        {
            case ShiftMode.None:
                ShiftMode = ShiftMode.UppercaseSingle;
                break;
            case ShiftMode.UppercaseSingle:
                ShiftMode = ShiftMode.UppercaseLock;
                break;
            case ShiftMode.UppercaseLock:
                ShiftMode = ShiftMode.None;
                break;
        }

        UpdateUppercase();
    }

    private void UpdateUppercase()
    {
        bool isUppercase = (ShiftMode != ShiftMode.None);

        foreach (var key in Keys)
        {
            key.SetUppercase(isUppercase);
        }

        UppercaseBehaviour?.UpdateImage(ShiftMode);
    }

    private void ToggleSymbols()
    {
        IsShowingSymbols = !IsShowingSymbols;

        if (IsShowingSymbols)
        {
            PopulatePanels(KeyboardSkin, Layout.Symbols);
        }
        else
        {
            PopulatePanels(KeyboardSkin, Layout.Normal);
        }
    }

    private void InitCanvas()
    {
        Canvas canvas = gameObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;

        CanvasScaler canvasScaler = gameObject.AddComponent<CanvasScaler>();
        GraphicRaycaster graphicRaycaster = gameObject.AddComponent<GraphicRaycaster>();

        // Set width to 200 and height to 100
        RectTransform r = GetComponent<RectTransform>();
        r.sizeDelta = new Vector2(200, 100);

        // Set position
        transform.position = new Vector3(0, 0, 150);
    }

    private void CreateMainPanel(KeyboardSkin skin)
    {
        // The main panel holds the four rows of the keyboard.
        MainPanel = new GameObject("Panel");
        MainPanel.transform.parent = transform;

        MainPanel.AddComponent<CanvasRenderer>();

        Image image = MainPanel.AddComponent<Image>();
        image.sprite = skin.GetBackgroundImage();
        image.pixelsPerUnitMultiplier = skin.GetBackgroundImagePixelsPerUnitMultiplier();

        // Sets the children rows to be vertically aligned
        VerticalLayoutGroup mainLayout = MainPanel.AddComponent<VerticalLayoutGroup>();
        mainLayout.spacing = -3;
        mainLayout.childControlHeight = false;
        mainLayout.childControlWidth = false;

        RectTransform rectTransform = MainPanel.GetComponent<RectTransform>();
        rectTransform.SetCentered();
    }


    private void PopulatePanels(KeyboardSkin skin, Layout layout)
    {
        // Remove all childrens of main panel
        foreach (Transform child in MainPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Clear the list of keys
        Keys = new List<KeyBehaviour>();

        // Set main panel background
        MainPanel.GetComponent<Image>().color = skin.KeyboardBackground;

        KeyboardLayout keyboardLayout = KeyboardLayoutHandler.GetLayout(layout);

        foreach (KeyboardRow keyboardRow in keyboardLayout.Rows)
        {
            GameObject row = InitRow("Row" + keyboardRow.RowIndex, MainPanel, keyboardRow.Spacing);
            Populate(row, keyboardRow, skin);
        }
    }

    private GameObject InitRow(string name, GameObject parent, float spacing)
    {
        GameObject row = new GameObject(name);
        row.transform.parent = parent.transform;
        CanvasRenderer canvasRenderer = row.AddComponent<CanvasRenderer>();

        // Set keys to be horizontally aligned
        HorizontalLayoutGroup firstRowLayout = row.AddComponent<HorizontalLayoutGroup>();
        firstRowLayout.childAlignment = TextAnchor.MiddleCenter;
        firstRowLayout.spacing = spacing;
        firstRowLayout.childControlHeight = false;
        firstRowLayout.childControlWidth = false;

        RectTransform rectTransform = row.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(200, 25);
        rectTransform.localPosition = new Vector3(0, 0, 0);

        return row;
    }


    private void Populate(GameObject parent, KeyboardRow row, KeyboardSkin skin)
    {
        foreach (KeyboardObject keyboardObject in row.Keys)
        {
            GameObject keyObj = new GameObject(keyboardObject.Name);
            keyObj.transform.parent = parent.transform;
            keyObj.transform.position = Vector3.zero;

            // Set key background image (rounded rectangle)
            Image backgroundImage = keyObj.AddComponent<Image>();
            backgroundImage.sprite = skin.GetKeyBackground();
            backgroundImage.type = Image.Type.Sliced;
            backgroundImage.color = skin.KeyBackground;

            if (keyboardObject is Spacer)
            {
                backgroundImage.color = Color.clear;
            }

            // Add the button
            Button button = keyObj.AddComponent<Button>();

            // Adds the shadow
            Shadow shadow = keyObj.AddComponent<Shadow>();
            shadow.effectColor = new Color(0, 0, 0, 80);
            shadow.effectDistance = new Vector2(0, -0.5f);

            // Adjust width and height
            RectTransform rectTransform = keyObj.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(keyboardObject.Width, keyboardObject.Height);
            rectTransform.localPosition = Vector3.zero;


            GameObject image = null;

            // Add image
            if (keyboardObject is ImageObjectButton imageObjectButton)
            {
                image = new GameObject("Image");
                image.transform.parent = keyObj.transform;

                Image img = image.AddComponent<Image>();
                img.sprite = Resources.Load<Sprite>(imageObjectButton.Image);

                RectTransform imgRectTransform = image.GetComponent<RectTransform>();
                imgRectTransform.sizeDelta = new Vector2(10, 10);
                imgRectTransform.localPosition = new Vector3(0, 0, 0);
            }

            // Add text
            if (keyboardObject is TextButton TextButton)
            {
                backgroundImage.color = new Color(
                    backgroundImage.color.r,
                    backgroundImage.color.g,
                    backgroundImage.color.b,
                    0.8f);

                TextButtonBehaviour keybhv = keyObj.AddComponent<TextButtonBehaviour>();
                keybhv.Init(TextButton, skin.KeyForeground);

                if (keyboardObject is Key key)
                {
                    KeyBehaviour keyBehaviour = keyObj.AddComponent<KeyBehaviour>();
                    keyBehaviour.Init(keybhv.Text);
                    Keys.Add(keyBehaviour);

                    button.onClick.AddListener(() => { Write(key.Name); });
                }
                else
                {
                    keybhv.SlightlyDarker();
                }
            }

            if (keyboardObject is UppercaseToggle uppercaseToggle)
            {
                UppercaseToggleBehaviour uppercaseToggleBehaviour = image.AddComponent<UppercaseToggleBehaviour>();
                uppercaseToggleBehaviour.Init(uppercaseToggle);

                UppercaseBehaviour = uppercaseToggleBehaviour;

                button.onClick.AddListener(ToggleUppercase);
            }

            if (keyboardObject is BackspaceButton)
            {
                button.onClick.AddListener(Backspace);
            }

            if (keyboardObject is SymbolsToggle)
            {
                button.onClick.AddListener(ToggleSymbols);
            }

            if (keyboardObject is SpaceBarButton)
            {
                button.onClick.AddListener(() => { Write(" "); });
            }
        }

        UpdateUppercase();
    }


    private void Write(string keyName)
    {
        Debug.Log("[Keyboard] Writing '" + keyName + "'.");

        string initialContent = target.text;

        if (ShiftMode != ShiftMode.None)
            keyName = keyName.ToUpper();

        string resultContent = initialContent + keyName;
        target.text = resultContent;

        // Disable shift if it's in single uppercase letter mode (not caps lock)
        if (ShiftMode == ShiftMode.UppercaseSingle)
        {
            ShiftMode = ShiftMode.None;
            UpdateUppercase();
        }
    }

    private void Backspace()
    {
        string initialContent = target.text;
        if (initialContent.Length > 0)
        {
            string resultContent = initialContent.Substring(0, initialContent.Length - 1);
            target.text = resultContent;
        }
    }
}


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