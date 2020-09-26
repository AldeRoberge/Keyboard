using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitCanvas();
        CreatePanels();
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
        GameObject mainPanel = new GameObject("Panel");
        mainPanel.transform.parent = transform;

        // Sets the children rows to be vertically aligned
        VerticalLayoutGroup mainLayout = mainPanel.AddComponent<VerticalLayoutGroup>();
        mainLayout.spacing = -3;

        GameObject rowOne = InitRow("RowOne", mainPanel, 0);
        GameObject rowTwo = InitRow("RowTwo", mainPanel, -18.5f);
        GameObject rowThree = InitRow("RowThree", mainPanel, -0.85f);
        GameObject rowFour = InitRow("RowFour", mainPanel, -0.85f);
    }

    private GameObject InitRow(string name, GameObject parent, float spacing)
    {
        GameObject row = new GameObject(name);
        row.transform.parent = parent.transform;
        
        // Set keys to be horizontally aligned
        HorizontalLayoutGroup firstRowLayout = row.AddComponent<HorizontalLayoutGroup>();
        firstRowLayout.childAlignment = TextAnchor.MiddleCenter;
        firstRowLayout.spacing = spacing;

        return row;
    }
}