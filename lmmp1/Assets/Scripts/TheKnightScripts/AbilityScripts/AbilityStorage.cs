using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityStorage : MonoBehaviour
{
    [SerializeField] private AbilityConfig[] _abilityConfigs;
    private List<Ability> _abilities = new();

    public void Init()
    {
        for (int i = 0; i < _abilityConfigs.Length; ++i)
        {
            var builder = _abilityConfigs[i].GetBuilder();
            builder.Make();
        }
    }
    public Ability[] GetAbilities() => _abilities.ToArray();
}
