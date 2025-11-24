using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FloatingDamage : MonoBehaviour
{
    [SerializeField] private GameObject fatherGameObject;
    private TextMeshPro damageText;

    public float TotalDamage;

    private void Start()
    {
       
        damageText = GetComponent<TextMeshPro>();
        damageText.text = "-" + TotalDamage.ToString("F1");

    }

    public void OnAnimationEnd()
    {
        Destroy(fatherGameObject);
    }
}
