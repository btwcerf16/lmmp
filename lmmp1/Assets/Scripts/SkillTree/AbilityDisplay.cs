using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityDisplay : MonoBehaviour
{
    public Ability ContentAbility;
    [SerializeField] private Sprite baseAbilityImage;
    [SerializeField] private TMP_Text coolDownText;
    [SerializeField] private TMP_Text keyText;
    [SerializeField] private Image abilityImage;

    public void SetData(Ability _ability)
    {
        
        if (_ability != null) 
        {
            ContentAbility = _ability;
            keyText.text = _ability.AbilityData.KeyActivation.ToString();
            abilityImage.sprite = _ability.AbilityData.AbilityIcon;
        }
        else { RemoveData(); }
    }
    public void RemoveData()
    {
        ContentAbility = null;
        coolDownText.text = "";
        keyText.text = "";
        abilityImage.sprite = baseAbilityImage;
    }
    private void Update()
    {
        if (ContentAbility != null) 
        {
            coolDownText.text = ContentAbility.CooldownTimeRemaining.ToString();
        }
    }

}
