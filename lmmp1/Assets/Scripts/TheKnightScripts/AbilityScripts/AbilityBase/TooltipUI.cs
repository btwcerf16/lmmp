using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TooltipUI : MonoBehaviour
{
    public static TooltipUI Instance;

    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject parent;
    private RectTransform parentRectTransform;

    private void Awake()
    {
        Instance = this;
        Hide();
        parentRectTransform = parent.GetComponent<RectTransform>();

    }

    public void Show(string tooltipText, Vector2 position)
    {
        text.text = tooltipText;
        parent.transform.position = new Vector2(position.x, position.y-300.0f);
        parent.SetActive(true);
    }
    public void Show(string tooltipText)
    {
        text.text = tooltipText;
        parent.SetActive(true);
    }

    public void Hide()
    {
        parent.SetActive(false);
    }
}
