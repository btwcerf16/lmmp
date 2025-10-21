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
            TextMeshProUGUI.text = $"Базовый урон от атак: {playerStats.attackDamage}" +
                "\n" +
                $"Бонусный урон от атак: {playerStats.BonusDamage}" +
                "\n" +
                $"Здоровье: {playerStats.СurrentHealth}/{playerStats.maxHealth}" +
                "\n" + 
                $"Выносливость: {playerStats.СurrentStamina}/{playerStats.maxStamina}" +
                "\n" +
                $"Регенерация выносливости: {playerStats.staminaRegeneration}" +
                "\n" +
                $"Множитель физ урона: {playerStats.physicDamageMultiplyer}" +
                "\n" +
                $"Множитель маг урона: {playerStats.magicDamageMultiplyer}" +
                "\n" +
                $"Сопротивление физ урону: {playerStats.physicResistance}" +
                "\n" +
                $"Сопротивление маг урону: {playerStats.magicResistance}" +
                "\n" +
                $"Шанс крит урона: {playerStats.critChance}" +
                "\n" +
                $"Крит урон: {playerStats.critDamage}";

            int effectsToShow = Mathf.Min(playerEffectHandler.ActiveEffects.Count, effectIcons.Count);

            for (int i = 0; i < effectsToShow; i++)
            {
                var effect = playerEffectHandler.ActiveEffects[playerEffectHandler.ActiveEffects.Count - 1 - i];
                var icon = effectIcons[i].GetComponent<Image>();
                icon.sprite = effect.EffectData.SpriteIcon;
                effectDescription[i].GetComponent<TextMeshProUGUI>().text = effect.EffectData.EffectName +
                "\n" +
                $"Описание: {effect.EffectData.EffectDescription}"+
                "\n" +
                $"Длительность: {effect.EffectData.EffectDuration}"

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
