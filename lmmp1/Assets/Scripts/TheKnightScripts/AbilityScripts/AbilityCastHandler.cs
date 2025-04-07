using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCastHandler : MonoBehaviour
{
    [SerializeField] private AbilityStorage _abilityStorage;
    [SerializeField] private Player _ownerPlayer;
    [SerializeField] private LayerMask _targetLayer;

    private List<Ability> _abilities = new();
    private Ability _currentAbility;

    private Camera _camera;

    public void Inject()
    {
        _camera = Camera.main;

        _abilityStorage.Init();
        _abilities.AddRange(_abilityStorage.GetAbilities());
    }

    public void OnClickAbilityButton(int abilityIndex)
    {
        switch (_abilities[abilityIndex].Status)
        {
            
            case EAbilityStatus.Ready:
                _currentAbility = _abilities[abilityIndex];
                _currentAbility.StartCast();
                break;
            case EAbilityStatus.Cooldown:
                break;
            case EAbilityStatus.NeedMana:
                break;
            default:
                break;
        }
    }
    private void Update()
    {
        for (int i = 0; i < _abilities.Count; ++i)
        {
            _abilities[i].EventTick(Time.deltaTime);
        }
        if (_currentAbility != null)
        {
            
        }
    }
}
