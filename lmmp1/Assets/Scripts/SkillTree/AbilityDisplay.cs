using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
            keyText.text = PrettyKey(_ability.AbilityData.KeyActivation);
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
            
            if(ContentAbility.CooldownTimeRemaining > 0)
            {
                coolDownText.text = ContentAbility.CooldownTimeRemaining.ToString("F1");
                abilityImage.color = Color.gray;
            }
            else
            {
                coolDownText.text = "";
                abilityImage.color = Color.white;
            }
        }
    }
    private string PrettyKey(KeyCode key)
    {
        string s = key.ToString();
        if (s.StartsWith("Alpha"))
            return s.Replace("Alpha", "");
        if (s.StartsWith("Keypad"))
            return "Num " + s.Replace("Keypad", "");
        if (s.Contains("Shift"))
            return "Shift";
        if (s.Contains("Control"))
            return "Ctrl";
        if (s.Contains("Alt"))
            return "Alt";

        return s;
    }
}
