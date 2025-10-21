using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EscMenu : MonoBehaviour
{
    private EffectHandler playerEffectHandler;
    
    public List<GameObject> effectIcons;
    public List<GameObject> effectDescription;

    [SerializeField]private ActorStats playerStats;
    private bool isActive;

    public GameObject EscPanel;
    public TextMeshProUGUI TextMeshProUGUI;
    private void Start()
    {
        playerEffectHandler = GetComponentInParent<EffectHandler>();    
       
        playerStats = GetComponentInParent<ActorStats>();
        if(EscPanel != null)
        {
            EscPanel.SetActive(false);
            isActive = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !isActive)
        {
            isActive = true;
            EscPanel.SetActive(true);
            TextMeshProUGUI.text = $"������� ���� �� ����: {playerStats.attackDamage}" +
                "\n" +
                $"�������� ���� �� ����: {playerStats.BonusDamage}" +
                "\n" +
                $"��������: {playerStats.�urrentHealth}/{playerStats.maxHealth}" +
                "\n" + 
                $"������������: {playerStats.�urrentStamina}/{playerStats.maxStamina}" +
                "\n" +
                $"����������� ������������: {playerStats.staminaRegeneration}" +
                "\n" +
                $"��������� ��� �����: {playerStats.physicDamageMultiplyer}" +
                "\n" +
                $"��������� ��� �����: {playerStats.magicDamageMultiplyer}" +
                "\n" +
                $"������������� ��� �����: {playerStats.physicResistance}" +
                "\n" +
                $"������������� ��� �����: {playerStats.magicResistance}" +
                "\n" +
                $"���� ���� �����: {playerStats.critChance}" +
                "\n" +
                $"���� ����: {playerStats.critDamage}";

            int effectsToShow = Mathf.Min(playerEffectHandler.ActiveEffects.Count, effectIcons.Count);

            for (int i = 0; i < effectsToShow; i++)
            {
                var effect = playerEffectHandler.ActiveEffects[playerEffectHandler.ActiveEffects.Count - 1 - i];
                var icon = effectIcons[i].GetComponent<Image>();
                icon.sprite = effect.EffectData.SpriteIcon;
                effectDescription[i].GetComponent<TextMeshProUGUI>().text = effect.EffectData.EffectName +
                "\n" +
                $"��������: {effect.EffectData.EffectDescription}"+
                "\n" +
                $"������������: {effect.EffectData.EffectDuration}"

                    ;

                effectIcons[i].SetActive(true);
            }

        }
        else if(Input.GetKeyUp(KeyCode.Escape) && isActive)
        {
            isActive = false;
            EscPanel.SetActive(false);
        }
    }
}
