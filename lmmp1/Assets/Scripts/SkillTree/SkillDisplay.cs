using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;
public class SkillDisplay : MonoBehaviour
{    
    public List<Image> AbilityImages;
    public List<TMP_Text> AbilityCooldownTexts;
    public List<TMP_Text> AbilityKeyTexts;
    private void Update()
    {
        for (int i = 0; i < AbilityCooldownTexts.Count; i++)
        {
            float coolDown = float.Parse(AbilityCooldownTexts[i].text);
            if (coolDown > 0)
            {
                AbilityCooldownTexts[i].text =(coolDown - Time.deltaTime).ToString();
            }
        }
    }
    public void ChangeAbilityImage(int _index, Sprite _image)
    {
        AbilityImages[_index].sprite = _image;
    }
    public void ChangeAbilityCooldown(int _index,float _coolDown)
    {
        AbilityCooldownTexts[_index].text = _coolDown.ToString();
    }
    public void ChangeAbilityKey(int _index, string _key)
    {
        AbilityKeyTexts[_index].text = _key;
    }
}
