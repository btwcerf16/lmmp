using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuffIconUI : MonoBehaviour
{
    public Text TextTimer; 
    private Image IconImage;
    public void Awake()
    {
        IconImage = GetComponent<Image>();
    }
    public void SetBuffSprite(Sprite sprite)
    {
        IconImage.sprite = sprite;

    }
    public void UpdateTimer(float timeRemaining)
    {
        TextTimer.text = timeRemaining.ToString("F1");
    }
}
