using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuffIconUI : MonoBehaviour
{

    private Image IconImage;
    public void Awake()
    {
        IconImage = GetComponent<Image>();
    }
    public void SetBuffSprite(Sprite sprite)
    {
        IconImage.sprite = sprite;
    }
}
