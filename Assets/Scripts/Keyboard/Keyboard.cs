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
    private GameObject _mainPanel;
    private List<KeyBehaviour> _keys;

    private Image _shiftToggleImage;

    private ShiftMode _shiftMode;
    private bool _isShowingSymbols;

    public TMP_InputField Target;

    private readonly KeyboardSkin _keyboardSkin = KeyboardSkins.defaultSkin;

    private UppercaseToggleBehaviour _uppercaseBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure there is a valid target (input field) for the keyboard
        if (Target == null)
        {
            Debug.LogError("[Keyboard] There is no target attached to this game object.\n" +
                           "Attach an object of type TMP_InputField on this script.");
            Destroy(this);
        }

        _shiftMode = ShiftMode.None;

        InitCanvas();
        CreateMainPanel(_keyboardSkin);
        PopulatePanels(_keyboardSkin, Layout.Normal);
    }

    private void ToggleUppercase()
    {
        switch (_shiftMode)
        {
            case ShiftMode.None:
                _shiftMode = ShiftMode.UppercaseSingle;
                break;
            case ShiftMode.UppercaseSingle:
                _shiftMode = ShiftMode.UppercaseLock;
                break;
            case ShiftMode.UppercaseLock:
                _shiftMode = ShiftMode.None;
                break;
        }

        UpdateUppercase();
    }

    private void UpdateUppercase()
    {
        bool isUppercase = (_shiftMode != ShiftMode.None);

        foreach (var key in _keys)
        {
            key.SetUppercase(isUppercase);
        }

        _uppercaseBehaviour?.UpdateImage(_shiftMode);
    }

    private void ToggleSymbols()
    {
        _isShowingSymbols = !_isShowingSymbols;

        if (_isShowingSymbols)
        {
            PopulatePanels(_keyboardSkin, Layout.Symbols);
        }
        else
        {
            PopulatePanels(_keyboardSkin, Layout.Normal);
        }
    }

    private void InitCanvas()
    {
        Canvas canvas = gameObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;

        gameObject.AddComponent<CanvasScaler>();
        gameObject.AddComponent<GraphicRaycaster>();

        // Set width to 200 and height to 100
        RectTransform r = GetComponent<RectTransform>();
        r.sizeDelta = new Vector2(200, 100);

        // Set position
        transform.position = new Vector3(0, 0, 150);
    }

    private void CreateMainPanel(KeyboardSkin skin)
    {
        // The main panel holds the four rows of the keyboard.
        _mainPanel = new GameObject("Panel");
        _mainPanel.transform.parent = transform;

        _mainPanel.AddComponent<CanvasRenderer>();

        Image image = _mainPanel.AddComponent<Image>();
        image.sprite = skin.GetBackgroundImage();
        image.pixelsPerUnitMultiplier = skin.GetBackgroundImagePixelsPerUnitMultiplier();
        image.type = Image.Type.Sliced;

        // Sets the children rows to be vertically aligned
        VerticalLayoutGroup mainLayout = _mainPanel.AddComponent<VerticalLayoutGroup>();
        mainLayout.spacing = -3;
        mainLayout.childControlHeight = false;
        mainLayout.childControlWidth = false;

        RectTransform rectTransform = _mainPanel.GetComponent<RectTransform>();
        rectTransform.SetCentered();
    }


    private void PopulatePanels(KeyboardSkin skin, Layout layout)
    {
        // Clear the main panel
        foreach (Transform child in _mainPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Clear the list of keys
        _keys = new List<KeyBehaviour>();

        // Clear the uppercase handler (it is recreated in Populate)
        _uppercaseBehaviour = null;

        // Set main panel background
        _mainPanel.GetComponent<Image>().color = skin.KeyboardBackground;

        KeyboardLayout keyboardLayout = KeyboardLayoutHandler.GetLayout(layout);

        foreach (KeyboardRow keyboardRow in keyboardLayout.Rows)
        {
            GameObject row = InitRow("Row" + keyboardRow.RowIndex, _mainPanel, keyboardRow.Spacing);
            Populate(row, keyboardRow, skin);
        }
    }

    private GameObject InitRow(string name, GameObject parent, float spacing)
    {
        GameObject row = new GameObject(name);
        row.transform.parent = parent.transform;
        row.AddComponent<CanvasRenderer>();

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
                    _keys.Add(keyBehaviour);

                    button.onClick.AddListener(() => { Write(key.Name); });
                }
                else
                {
                    keybhv.SlightlyDarker();
                }
            }

            if (keyboardObject is UppercaseToggle uppercaseToggle)
            {
                _uppercaseBehaviour = image.AddComponent<UppercaseToggleBehaviour>();
                _uppercaseBehaviour.Init(uppercaseToggle);

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

        string initialContent = Target.text;

        if (_shiftMode != ShiftMode.None)
            keyName = keyName.ToUpper();

        string resultContent = initialContent + keyName;
        Target.text = resultContent;

        // Disable shift if it's in single uppercase letter mode (not caps lock)
        if (_shiftMode == ShiftMode.UppercaseSingle)
        {
            _shiftMode = ShiftMode.None;
            UpdateUppercase();
        }
    }

    private void Backspace()
    {
        string initialContent = Target.text;
        if (initialContent.Length > 0)
        {
            string resultContent = initialContent.Substring(0, initialContent.Length - 1);
            Target.text = resultContent;
        }
    }
}