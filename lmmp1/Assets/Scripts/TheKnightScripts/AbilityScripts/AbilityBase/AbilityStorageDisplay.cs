using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AbilityStorageDisplay : MonoBehaviour
{
    public GameObject AbilityStoragePanel;
    public GameObject AbilityItemPrefab;
    public List<GameObject> AbilityStorageItems;
    public List<Image> ActiveAbilityStorage;
    [SerializeField] private Sprite baseIcon;

    public void AddAbilityItem(Ability _ability)
    {
        var abilityItem = Instantiate(AbilityItemPrefab, AbilityStoragePanel.transform);
        abilityItem.GetComponent<AbilityItemDisplay>().ChangeItemData(_ability);
        AbilityStorageItems.Add(abilityItem);

    }
    public void SetPreviewAbility(Sprite _sprite)
    {
        if (ActiveAbilityStorage != null)
        {
            for (int i = 0; i < ActiveAbilityStorage.Count; i++)
            {
                if (ActiveAbilityStorage[i].sprite == baseIcon)
                {
                    ActiveAbilityStorage[i].sprite = _sprite;

                    break;
                }
            }
        }
    }
    public void UnSetPreviewAbility(Sprite _sprite)
    {
        if (ActiveAbilityStorage != null)
        {
            for (int i = 0; i < ActiveAbilityStorage.Count; i++)
            {
                if (ActiveAbilityStorage[i].sprite == _sprite)
                {
                    ActiveAbilityStorage[i].sprite = baseIcon;
                    if (i != ActiveAbilityStorage.Count - 1)
                    {
                        for (int j = i; j < ActiveAbilityStorage.Count-1; j++)
                        {
                            ActiveAbilityStorage[j].sprite = ActiveAbilityStorage[j + 1].sprite;
                        }

                        break;
                    }
                }
            }

        }

    }
}