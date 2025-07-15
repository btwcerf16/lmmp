using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingDamage : MonoBehaviour
{
    [HideInInspector ] public float TotalDamage;

    private TextMesh damageText;

    private void Start()
    {
         damageText = GetComponent<TextMesh>();
        damageText.text = TotalDamage.ToString();
    }

    public void AnimationEnd()
    {
        Destroy(gameObject);
    }
}
