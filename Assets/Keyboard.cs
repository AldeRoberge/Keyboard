using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitCanvas();
        CreatePanels();
        PopulatePanels();
    }


    public GameObject MainPanel;

    private void PopulatePanels(Layout layout = Layout.Normal)
    {
        // Remove all childs of main panel
        foreach (GameObject child in MainPanel.transform)
        {
            Destroy(child.gameObject);
        }

        KeyboardLayout keyboardLayout = KeyboardLayoutHandler.GetLayout(layout);

        foreach (KeyboardRow keyboardRow in keyboardLayout.Rows)
        {
            GameObject row = InitRow("Row" + keyboardRow.RowIndex, MainPanel, keyboardRow.Spacing);
            Populate(row, keyboardRow);
        }
    }

    private void Populate(GameObject parent, KeyboardRow row)
    {
        foreach (KeyboardObject keyboardObject in row.Keys)
        {
            GameObject keyObj = new GameObject(keyboardObject.ToString());
            keyObj.transform.parent = parent.transform;

            // Set key background image (rounded rectangle)
            Image backgroundImage = keyObj.AddComponent<Image>();
            backgroundImage.sprite = Resources.Load<Sprite>("KeyBackgroundImage");

            
            // Add a button
            Button button = keyObj.AddComponent<Button>();

            
            // Adds a hard shadow
            Shadow shadow = keyObj.AddComponent<Shadow>();
            shadow.effectColor = new Color(0, 0, 0, 80);
            shadow.effectDistance = new Vector2(0, -0.5f);


            // Adjust width and height
            RectTransform rectTransform = keyObj.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(keyboardObject.Width, keyboardObject.Height);


            if (keyboardObject is ImageObjectButton imageObjectButton)
            {
                GameObject image = new GameObject("Image");
                image.transform.parent = keyObj.transform;

                Image img = image.AddComponent<Image>();
                img.sprite = Resources.Load<Sprite>(imageObjectButton.ImageResourcePath);
            }


            if (keyboardObject is Key key)
            {
                keyObj.AddComponent<KeyBehaviour>();
            }
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

    private void CreatePanels()
    {
        // The main panel holds the four rows of the keyboard.
        MainPanel = new GameObject("Panel");
        MainPanel.transform.parent = transform;
        

        // Sets the children rows to be vertically aligned
        VerticalLayoutGroup mainLayout = MainPanel.AddComponent<VerticalLayoutGroup>();
        mainLayout.spacing = -3;
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

        return row;
    }
}