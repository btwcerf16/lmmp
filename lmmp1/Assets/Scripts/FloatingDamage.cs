using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatingDamage : MonoBehaviour
{
    
   private TextMeshPro damageText;
    [SerializeField] public float TotalDamage;

    private void Start()
    {
        damageText = GetComponent<TextMeshPro>();
        damageText.text = "-" + TotalDamage;
        
    }

    public void AnimationEnd()
    {
        Destroy(gameObject);
    }
}
