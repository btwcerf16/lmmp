using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using System;

public class AbilityStorageDisplay : MonoBehaviour
{
    public GameObject AbilityStoragePanel;
    public GameObject AbilityItemPrefab;
    public List<GameObject> AbilityStorageItems;

    public void AddAbilityItem(Ability _ability)
    {
        var abilityItem = AbilityItemPrefab;
        abilityItem.GetComponent<AbilityItemDisplay>().ChangeItemData(_ability);
        AbilityStorageItems.Add(abilityItem);
        Instantiate(abilityItem, AbilityStoragePanel.transform);
    }
}
