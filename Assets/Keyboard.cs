using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Keyboard : MonoBehaviour
{
    public GameObject MainPanel;


    // Start is called before the first frame update
    void Start()
    {
        InitCanvas();
        CreatePanels();
        PopulatePanels(KeyboardSkins.defaultSkin);
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

    private void CreatePanels()
    {
        // The main panel holds the four rows of the keyboard.
        MainPanel = new GameObject("Panel");
        MainPanel.transform.parent = transform;

        MainPanel.AddComponent<CanvasRenderer>();

        MainPanel.AddComponent<Image>().sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");

        // Sets the children rows to be vertically aligned
        VerticalLayoutGroup mainLayout = MainPanel.AddComponent<VerticalLayoutGroup>();
        mainLayout.spacing = -3;
        mainLayout.childControlHeight = false;
        mainLayout.childControlWidth = false;

        RectTransform rectTransform = MainPanel.GetComponent<RectTransform>();
        rectTransform.SetCentered();
    }


    private void PopulatePanels(KeyboardSkin skin, Layout layout = Layout.Normal)
    {
        // Remove all childs of main panel
        foreach (GameObject child in MainPanel.transform)
        {
            Destroy(child.gameObject);
        }

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
            GameObject keyObj = new GameObject(keyboardObject.ToString());
            keyObj.transform.parent = parent.transform;
            keyObj.transform.position = Vector3.zero;

            // Set key background image (rounded rectangle)
            Image backgroundImage = keyObj.AddComponent<Image>();
            backgroundImage.sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
            backgroundImage.type = Image.Type.Sliced;
            backgroundImage.color = skin.KeyBackground;

            // Add a button
            Button button = keyObj.AddComponent<Button>();

            // Adds a hard shadow
            Shadow shadow = keyObj.AddComponent<Shadow>();
            shadow.effectColor = new Color(0, 0, 0, 80);
            shadow.effectDistance = new Vector2(0, -0.5f);

            // Adjust width and height
            RectTransform rectTransform = keyObj.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(keyboardObject.Width, keyboardObject.Height);
            rectTransform.localPosition = Vector3.zero;

            if (keyboardObject is ImageObjectButton imageObjectButton)
            {
                GameObject image = new GameObject("Image");
                image.transform.parent = keyObj.transform;

                Image img = image.AddComponent<Image>();
                img.sprite = Resources.Load<Sprite>(imageObjectButton.ImageResourcePath);

                RectTransform imgRectTransform = image.GetComponent<RectTransform>();
                imgRectTransform.sizeDelta = new Vector2(10, 10);
            }

            if (keyboardObject is Key key)
            {
                KeyBehaviour keybhv = keyObj.AddComponent<KeyBehaviour>();
                keybhv.Init(key, skin.KeyForeground);
            }
        }
    }
}