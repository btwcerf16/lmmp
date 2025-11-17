using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipUI : MonoBehaviour
{
    public static TooltipUI Instance;

    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject parent;

    private void Awake()
    {
        Instance = this;
        Hide();
    }

    public void Show(string tooltipText, Vector2 position)
    {
        text.text = tooltipText;
        parent.transform.position = position;
        parent.SetActive(true);
    }

    public void Hide()
    {
        parent.SetActive(false);
    }
}
