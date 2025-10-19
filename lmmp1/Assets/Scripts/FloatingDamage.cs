using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        damageText.text = "-" + TotalDamage;
        
    }

    public void OnAnimationEnd()
    {
        Destroy(fatherGameObject);
    }
}
